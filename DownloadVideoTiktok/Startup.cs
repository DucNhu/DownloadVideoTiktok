using System;
using DownloadVideoTiktok.Infrastructure;
using DownloadVideoTiktok.Infrastructure.Extractor;
using DownloadVideoTiktok.Models;
using DownloadVideoTiktok.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;

namespace DownloadVideoTiktok
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<DvtDatabaseSettings>(Configuration.GetSection(nameof(DvtDatabaseSettings)));
            services.Configure<WebConfig>(Configuration.GetSection(nameof(WebConfig)));

            services.AddSingleton<IDvtDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DvtDatabaseSettings>>().Value);

            services.AddSingleton<UserService>();
            services.AddSingleton<UserReferenceService>();
            services.AddSingleton<HistoryDownloadService>();
            services.AddSingleton<UserTransactionService>();
            services.AddSingleton<UserPackageService>();
            services.AddSingleton<ArticleService>();
            services.AddSingleton<VideoSourceService>();

            services.AddSingleton<TiktokExtractor>();
            services.AddSingleton<DouyinExtractor>();
            services.AddSingleton<YoukuExtractor>();
            services.AddSingleton<FacebookExtractor>();
            services.AddSingleton<BilibiliExtractor>();
            services.AddSingleton<DailymotionExtractor>();
            services.AddSingleton<IxiguaExtractor>();
            services.AddSingleton<KakaoExtractor>();
            services.AddSingleton<YoutubeExtractor>();
            services.AddSingleton<PaypalApi>();
            services.AddSingleton<FileUtility>();

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.LoginPath = "/";
                options.LogoutPath = "/";
                options.ExpireTimeSpan = TimeSpan.FromHours(1);
                options.SlidingExpiration = true;
            });

            services.AddAntiforgery(options =>
            {
                options.HeaderName = "XSRF-TOKEN";
                options.SuppressXFrameOptionsHeader = false;
            });

            services.AddNodeServices();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .Enrich.FromLogContext();

            loggerFactory.AddSerilog();

            Log.Logger = logger.CreateLogger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "AreaAdmin",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
