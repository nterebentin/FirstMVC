using FirstMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVC.Controllers
{
    public class ArtistController : Controller
    {
        public IActionResult Index()
        {
            ChinookContext cnt = new ChinookContext();
            return View(cnt.Artists.ToList());
        }
        public IActionResult AlbumsByArtist(int id)
        {
            ChinookContext cnt = new();
            List<Album> albums = cnt.Albums.Where(x => x.ArtistId == id).ToList();
            return View(albums);

        }
        // HTTP GET VERSION
        public IActionResult Create()
        {
            return View();
        }

        // HTTP POST VERSION  
        [HttpPost]
        public IActionResult Create(Artist artist)
        {
            ChinookContext context = new ChinookContext();
            context.Artists.Add(artist);
            context.SaveChanges(); 
            return View("Thanks", artist);
        }
    }
}
