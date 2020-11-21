using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace shortener.Data
{
    [ApiController]
    public class ShortlinkController : Controller
    {
        private SHSHConnector _connector = new SHSHConnector();
        [Route("/{id}")]
        public IActionResult Redirect(string id)
        {
            var dbSearch = from x in _connector.Links where x.Link == id select x;
            if (dbSearch.Any())
            {
                return RedirectPermanent(dbSearch.First().Redirect);
            }
            else
            {
                return NotFound("The requested shortcode was not found!");
            }
        }
        [Route("/{id}/stat")]
        public IActionResult RedirectInfo(string id)
        {
            var dbSearch = from x in _connector.Links where x.Link == id select x;
            if (dbSearch.Any())
            {
                return Json(dbSearch.First());
            }
            else
            {
                return NotFound("The requested shortcode was not found!");
            }
        }
    }
}