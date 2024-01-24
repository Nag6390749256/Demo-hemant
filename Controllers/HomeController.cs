using DAPPER_CURD.AppCode.Hellper;
using DAPPER_CURD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace DAPPER_CURD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUserService _userService;
        private IFileUploadService _fileUploadService;
        public HomeController(ILogger<HomeController> logger, IUserService userService, IFileUploadService fileUploadService)
        {
            _logger = logger;
            _userService = userService;
            _fileUploadService = fileUploadService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var list = _userService.GetUsersList();
            return View(list);
        }
        [HttpPost]
        public IActionResult Save(string JsonString,IFormFile formFile)
        {
            var request = JsonConvert.DeserializeObject<Users>(JsonString);
            request.FileURL = string.Empty;
            if (formFile != null)
            {
                var fileRes = _fileUploadService.Upload(new FileUploadModel
                {
                    file = formFile,
                    FileName = DateTime.Now.ToString("ddMMyyyyhhmmssfff"),
                    FilePath = "document/"
                });
                if (fileRes.StatusCode == -1)
                {
                    return Json(fileRes);
                }
                request.FileURL = fileRes.ResponseText;
            }
            var res = _userService.Save(request);
            return Json(res);
        }
        [HttpGet]
        public IActionResult edit(int Id)
        {
            var data = _userService.GetUsersById(Id);
            return View(data);
        }
        [HttpPost]
        public IActionResult delete(int Id)
        {
            var data = _userService.Delete(Id);
            return Json(data);
        }
    }
}
