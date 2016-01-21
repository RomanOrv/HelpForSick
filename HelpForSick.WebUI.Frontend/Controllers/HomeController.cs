using HelpForSick.Entities;
using HelpForSick.Repository;
using HelpForSick.WebUI.Frontend.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Cloudinary.Mvc;

namespace HelpForSick.WebUI.Frontend.Controllers
{
    public class HomeController : Controller
    {

        private readonly IArticleRepository _articleRepository;
        private readonly IPersonPageInfoRepository _personRepository;

        public HomeController(IArticleRepository articleRepository, IPersonPageInfoRepository personRepository)
        {
            this._articleRepository = articleRepository;
            this._personRepository = personRepository;
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

        // GET: Home
        public ActionResult PersonPage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult WritePersonInfo()
        {
            return View();
        }



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


        [HttpGet]
        public ActionResult NewArticle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewArticle(CreateArticleModel article)
        {
            if (ModelState.IsValid)
            {
                _articleRepository.CreateArticle(article.Title);

                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpPost]
        public ActionResult SaveFormattedPersonInfo(PersonInfoModel model)
        {
            //string decodedMainInfo = string.Empty;
            //string decodedDiagnosis = string.Empty;
            //string decodedMoneyInfo = string.Empty;
            //if (formattedMainInfo != string.Empty)
            //{
            //     decodedMainInfo = Server.UrlDecode(formattedMainInfo);
            //}
            //if (formattedDiagnosis != string.Empty)
            //{
            //    decodedDiagnosis = Server.UrlDecode(formattedDiagnosis);
            //}
            //if (formattedMoneyInfo != string.Empty)
            //{
            //    decodedMoneyInfo = Server.UrlDecode(formattedMoneyInfo);
            //}
            var image = model.Images;

            CloudinaryDotNet.Account account = new CloudinaryDotNet.Account("df0y2fmjb", "339727939792644", "zUdYMjTI2P1QLNPJeTrYugstHPA");
            //CloudinaryDotNet.Cloudinary cloudinary = new CloudinaryDotNet.Cloudinary(account);

       _personRepository.SetPersonPageInfo(model.MainInfo, model.Diagnosis, model.MoneyInfo);
            return Json(new { });
        }

        [HttpPost]
        public ActionResult GetFormattedPersonInfo()
        {
            string encodeMainInfo = string.Empty;
            string encodeDiagnosis = string.Empty;
            string encodeMoneyInfo = string.Empty;
            PersonPageInfo personInfo = _personRepository
                                    .GetPersonPageInfo();

            if (personInfo.MainInfo != string.Empty)
            {
                encodeMainInfo = Server.UrlDecode(personInfo.MainInfo);
            }
            if (personInfo.Diagnosis != string.Empty)
            {
                encodeDiagnosis = Server.UrlDecode(personInfo.Diagnosis);
            }
            if (personInfo.MoneyInfo != string.Empty)
            {
                encodeMoneyInfo = Server.UrlDecode(personInfo.MoneyInfo);
            }

            return Json(new
            {
                encodeMainInfo = encodeMainInfo,
                encodeDiagnosis = encodeDiagnosis,
                encodeMoneyInfo = encodeMoneyInfo
            });
        }
    }
}