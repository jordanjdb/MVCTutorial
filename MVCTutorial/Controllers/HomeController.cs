using MVCTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTutorial.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult AlbumTitleSearch(string q)
        {
            MusicStoreDB db = new MusicStoreDB();
            var albums = db.Albums.Where(a => a.Title.Contains(q)).ToList();

            return View(albums);

        }
		public ActionResult ArtistSearch(string q) {
			MusicStoreDB db = new MusicStoreDB();
			var artists = db.Artists.Where(a => a.Name.Contains(q)).ToList();

			return PartialView("_ArtistSearch",artists);

		}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
	}
}