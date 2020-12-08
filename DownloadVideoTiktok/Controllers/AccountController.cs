using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DownloadVideoTiktok.Models;
using System.Net;
using HtmlAgilityPack;
using System.Net.Http;
using Microsoft.Net.Http.Headers;
using DownloadVideoTiktok.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Net.WebSockets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DownloadVideoTiktok.Infrastructure;
using Microsoft.Extensions.Options;

namespace DownloadVideoTiktok.Controllers
{
    public class AccountController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserService userService;
        private readonly UserReferenceService userReferenceService;
        private readonly HistoryDownloadService historyDownloadService;
        private readonly UserTransactionService userTransactionService;
        private readonly UserPackageService userPackageService;
        private readonly PaypalApi paypalApi;
        private readonly IOptions<WebConfig> webConfig;

        public AccountController(ILogger<HomeController> logger,
            UserService userService,
            UserReferenceService userReferenceService,
            HistoryDownloadService historyDownloadService,
            UserTransactionService userTransactionService,
            UserPackageService userPackageService,
            PaypalApi paypalApi, 
            IOptions<WebConfig> webConfig)
        {
            _logger = logger;
            this.userService = userService;
            this.userReferenceService = userReferenceService;
            this.historyDownloadService = historyDownloadService;
            this.userTransactionService = userTransactionService;
            this.userPackageService = userPackageService;
            this.paypalApi = paypalApi;
            this.webConfig = webConfig;
        }

        [Authorize]
        [HttpPost("/createPayment")]
        public async Task<IActionResult> CreatePayment(string package)
        {
            var price = (double)0;

            switch (package)
            {
                case "WEEK":
                    price = 2.5;
                    break;
                case "MONTH":
                    price = 7.5;
                    break;
                case "YEAR":
                    price = 65;
                    break;
                default:
                    break;
            }

            if (price == 0)
            {
                return new JsonResult(new
                {
                    error = true,
                    message = "Upgrade failed"
                });
            }

            var _userTransaction = new UserTransaction()
            {
                UserId = UserId,
                Type = "PAYPAL",
                ReferenceCode = package,
                Cost = price,
                IsPlus = true,
                DateCreated = DateTime.Now,
                IsActive = false,
                IsDeleted = false
            };

            userTransactionService.Create(_userTransaction);

            var quantiy = 1;

            var dataOrder = new
            {
                intent = "CAPTURE",
                //application_context = new
                //{
                //    return_url = string.Empty,
                //    cancel_url = string.Empty
                //},
                purchase_units = new[]
                {
                    new
                    {
                        reference_id = _userTransaction.Id,
                        description = $"BUY {package}",
                        invoice_id = _userTransaction.Id,
                        custom_id = UserId,
                        amount = new
                        {
                            currency_code = "USD",
                            value = price,
                            breakdown = new
                            {
                                item_total = new
                                {
                                    currency_code = "USD",
                                    value = price * quantiy
                                }
                            }
                        },
                        items = new[]
                        {
                            new {
                                name = package,
                                sku = package,
                                unit_amount = new
                                {
                                    currency_code = "USD",
                                    value = price
                                },
                                quantity = quantiy
                            }
                        }
                    }
                }
            };

            var orderId = await paypalApi.GetOrderId(dataOrder);

            _userTransaction.TransactionId = orderId;

            userTransactionService.Update(_userTransaction.Id, _userTransaction);

            return new JsonResult(new
            {
                error = false,
                message = "Create payment success",
                data = orderId
            });
        }

        [HttpPost("/updatePayment")]
        public async Task<IActionResult> UpdatePayment(string orderId)
        {
            try
            {
                var orderDetail = JObject.FromObject(await paypalApi.CaptureOrder(orderId));

                if (orderDetail["status"].ToString() == "COMPLETED")
                {
                    var _userTransaction = userTransactionService.GetByTransaction(orderId);

                    if (_userTransaction.IsActive == true)
                    {
                        return new JsonResult(new
                        {
                            error = true,
                            message = "Transaction updated"
                        });
                    }

                    _userTransaction.IsActive = true;

                    userTransactionService.Update(_userTransaction.Id, _userTransaction);

                    var dateExpired = userPackageService.GetDateExpiredUser(UserId) ?? DateTime.Now;

                    switch (_userTransaction.ReferenceCode)
                    {
                        case "WEEK":
                            dateExpired = dateExpired.AddDays(7);
                            break;
                        case "MONTH":
                            dateExpired = dateExpired.AddMonths(1);
                            break;
                        case "YEAR":
                            dateExpired = dateExpired.AddYears(1);
                            break;
                        default:
                            break;
                    }

                    var _userPackage = new UserPackage()
                    {
                        UserId = UserId,
                        Package = _userTransaction.ReferenceCode,
                        Cost = _userTransaction.Cost,
                        DateExpired = dateExpired,
                        DateCreated = DateTime.Now,
                        IsActive = true,
                        IsDeleted = false
                    };

                    userPackageService.Create(_userPackage);

                    userTransactionService.Create(new UserTransaction()
                    {
                        UserId = UserId,
                        Type = "Upgrade",
                        ReferenceCode = _userPackage.Id,
                        Cost = _userTransaction.Cost,
                        IsPlus = false,
                        DateCreated = DateTime.Now,
                        IsActive = true,
                        IsDeleted = false
                    });
                }

                return new JsonResult(new
                {
                    error = false,
                    message = "Upgrade success"
                });
            }
            catch (Exception ex)
            {

            }

            return new JsonResult(new
            {
                error = true,
                message = "Upgrade failed"
            });
        }

        [Authorize]
        [HttpPost("/upgrade")]
        public IActionResult Upgrade(string package)
        {
            var balance = userTransactionService.GetBalance(UserId);

            var _dateExpired = userPackageService.GetDateExpiredUser(UserId);

            if (balance < 1)
            {
                return new JsonResult(new
                {
                    error = true,
                    message = "You need 1$",
                    data = package
                });
            }

            var _newDateExpired = (_dateExpired ?? DateTime.Now).AddDays(1);

            var _userPackage = new UserPackage()
            {
                UserId = UserId,
                Package = "DAY",
                Cost = 1,
                DateExpired = _newDateExpired,
                DateCreated = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            };

            userPackageService.Create(_userPackage);

            userTransactionService.Create(new UserTransaction()
            {
                UserId = UserId,
                Type = "Upgrade",
                ReferenceCode = _userPackage.Id,
                Cost = 1,
                IsPlus = false,
                DateCreated = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            });

            return new JsonResult(new
            {
                error = false,
                message = "Upgrade success",
                data = _newDateExpired.ToString("yyyy/MM/dd")
            });
        }

        [Authorize]
        [HttpGet("/upgrade")]
        public IActionResult Upgrade()
        {
            var _dateExpired = userPackageService.GetDateExpiredUser(UserId);

            ViewBag.DateExpired = _dateExpired.HasValue ? _dateExpired.Value.ToString("yyyy/MM/dd") : "NONE";

            return View();
        }

        [Authorize]
        [HttpGet("/transactions")]
        public IActionResult Transactions()
        {
            ViewBag.Balance = userTransactionService.GetBalance(UserId);

            var page = !string.IsNullOrEmpty(Request.Query["page"]) ? int.Parse(Request.Query["page"]) : 1;

            (var list, var total) = userTransactionService.GetByUser(UserId, (page - 1) * 10, 10);

            var model = new PageListModel<UserTransaction>
            {
                List = list,
                Total = total,
                PageSize = 10,
                CurrentPage = page
            };

            return View(model);
        }

        [Authorize]
        [HttpGet("/history-download")]
        public IActionResult HistoryDownload()
        {
            var page = !string.IsNullOrEmpty(Request.Query["page"]) ? int.Parse(Request.Query["page"]) : 1;

            (var list, var total) = historyDownloadService.GetByUser(UserId, (page - 1) * 10, 10);

            var model = new PageListModel<HistoryDownload>
            {
                List = list,
                Total = total,
                PageSize = 10,
                CurrentPage = page
            };

            ViewBag.IsVip = userPackageService.GetDateExpiredUser(UserId) >= DateTime.Now;

            return View(model);
        }

        [Authorize]
        [HttpGet("/reference")]
        public IActionResult Reference()
        {
            var page = !string.IsNullOrEmpty(Request.Query["page"]) ? int.Parse(Request.Query["page"]) : 1;

            (var list, var total) = userReferenceService.GetByUser(UserId, (page - 1) * 10, 10);

            var model = new PageListModel<UserReference>
            {
                List = list,
                Total = total,
                PageSize = 10,
                CurrentPage = page
            };

            return View(model);
        }

        [Authorize]
        [HttpGet("/change-password")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost("/change-password")]
        [ValidateAntiForgeryToken]
        public IActionResult ChangePassword(string currentPassword, string newPassword, string renewPassword)
        {
            if (string.IsNullOrEmpty(currentPassword)
                || string.IsNullOrEmpty(newPassword)
                || string.IsNullOrEmpty(renewPassword))
            {
                return new JsonResult(new
                {
                    error = true,
                    message = "Please enter information",
                    data = string.Empty
                });
            }

            if (newPassword != renewPassword)
            {
                return new JsonResult(new
                {
                    error = true,
                    message = "Password not match",
                    data = string.Empty
                });
            }

            var user = userService.Get(UserId);

            if (user.Password != currentPassword)
            {
                return new JsonResult(new
                {
                    error = true,
                    message = "Wrong current password",
                    data = string.Empty
                });
            }

            user.Password = newPassword;

            userService.Update(UserId, user);

            return new JsonResult(new
            {
                error = false,
                message = "Change password success",
                data = string.Empty
            });
        }

        [HttpGet("/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/");
        }

        [HttpGet("/signup")]
        public IActionResult SignUp()
        {
            if (User.Identity.IsAuthenticated) return Redirect("/");

            return View();
        }

        [HttpGet("/signin")]
        public IActionResult SignIn()
        {
            if (User.Identity.IsAuthenticated) return Redirect("/");

            return View();
        }

        [HttpPost("/login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (!IsCheckReCaptcha) return new JsonResult(new
            {
                error = true,
                message = "Please verify captcha."
            });

            if (string.IsNullOrEmpty(username)
                || string.IsNullOrEmpty(password))
            {
                return new JsonResult(new
                {
                    error = true,
                    message = "Please enter information",
                    data = string.Empty
                });
            }

            var user = userService.GetByAuth(username, password);

            if (user == null)
            {
                return new JsonResult(new
                {
                    error = true,
                    message = "Wrong account",
                    data = string.Empty
                });
            }

            await AddCookieAuth(user);

            return new JsonResult(new
            {
                error = false,
                message = "Login success",
                data = string.Empty
            });
        }

        [HttpPost("/register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(string username, string password, string repassword)
        {
            if (!IsCheckReCaptcha) return new JsonResult(new
            {
                error = true,
                message = "Please verify captcha."
            });

            if (string.IsNullOrEmpty(username)
                || string.IsNullOrEmpty(password)
                || string.IsNullOrEmpty(repassword))
            {
                return new JsonResult(new
                {
                    error = true,
                    message = "Please enter information",
                    data = string.Empty
                });
            }

            if (repassword != password)
            {
                return new JsonResult(new
                {
                    error = true,
                    message = "Please enter password dupplicate",
                    data = string.Empty
                });
            }

            if (userService.CheckUserExisted(username))
            {
                return new JsonResult(new
                {
                    error = true,
                    message = "Account Existed",
                    data = string.Empty
                });
            }

            var user = userService.Create(new Models.User()
            {
                Username = username,
                Password = password,
                DateCreated = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            });

            await AddCookieAuth(user);

            var referer = Request.Headers["Referer"].ToString();

            if (!string.IsNullOrEmpty(referer))
            {
                var _urlReferer = new Uri(referer);

                var queryDictionary = System.Web.HttpUtility.ParseQueryString(_urlReferer.Query);

                var _username = queryDictionary["ref"];

                if (!string.IsNullOrEmpty(_username))
                {
                    var _userReffer = userService.GetByUsername(_username);

                    if (_userReffer != null)
                    {
                        var _reference = new UserReference()
                        {
                            UserId = _userReffer.Id,
                            UserReferenceId = user.Id,
                            Username = user.Username,
                            Earn = 0.5,
                            DateCreated = DateTime.Now,
                            IsActive = true,
                            IsDeleted = false
                        };

                        userReferenceService.Create(_reference);

                        userTransactionService.Create(new UserTransaction()
                        {
                            UserId = _userReffer.Id,
                            Type = "Reference",
                            ReferenceCode = _reference.Id,
                            Cost = +0.5,
                            IsPlus = true,
                            DateCreated = DateTime.Now,
                            IsActive = true,
                            IsDeleted = false
                        });
                    }
                }                
            }

            return new JsonResult(new
            {
                error = false,
                message = "Regiser success",
                data = string.Empty
            });
        }        

        public IActionResult AccessDenied()
        {
            return Redirect("/");
        }

        private async Task AddCookieAuth(User user)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.Username)
            };

            if (user.Username == "vdhd_admin@videodownhd.com" || user.Username == "bienlv@videodownhd.com") claims.Add(new Claim(ClaimTypes.Role, "ADMIN"));

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)),
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(webConfig.Value.MinuteExpiredSession)
                });

            var cookieAuth = Response.Headers["Set-Cookie"].ToString().Replace(".AspNetCore.Cookies=", string.Empty).Split(';')[0];

            user.LastToken = cookieAuth;

            userService.Update(user.Id, user);

            //.AspNetCore.Cookies
            //.AspNetCore.Cookies=

        }
    }
}
