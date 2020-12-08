using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DownloadVideoTiktok.Areas.Admin.Controllers
{
    [Authorize(Roles = "ADMIN")]
    [Area("Admin")]
    public class BaseAdminController : Controller
    {
        
    }
}
