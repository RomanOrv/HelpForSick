using HelpForSick.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpForSick.WebUI.Frontend.Controllers
{
    public class HomeController : Controller
    {

        private readonly IArticleRepository _articleRepository;

        public HomeController(IArticleRepository articleRepository)
        {
            this._articleRepository = articleRepository;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        //[HttpGet]
        //public ActionResult ShowArticle(string title, int id, int authorId)
        //{
        //    ViewBag.ArTitle = title;
        //    ViewBag.Id = id;
        //    return View();
        //}





        [HttpGet]
        public ActionResult WriteArticle()
        {
            return View();
        }




        [HttpPost]
        public ActionResult GetFormattedText()
        {
            string formattedText = _articleRepository
                                    .GetArticle()
                                    .Content;


            string encodedText = Server.UrlEncode(formattedText);
            return Json(new
            {
                formattedText = encodedText
            });
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult GetFormattedText_Show()
        {
            string formattedText = _articleRepository
                                    .GetArticle()
                                    .Content;

            string encodedText = Server.UrlEncode(formattedText);
            return Json(new
            {
                formattedText = encodedText
            });
        }


        [HttpPost]
        public ActionResult SaveFormattedText(string formattedText)
        {
            if (formattedText != string.Empty)
            {
                var decodedText = Server.UrlDecode(formattedText);
                _articleRepository.SetArticleContent(decodedText);
            }
            return Json(new { });
        }
    }
}