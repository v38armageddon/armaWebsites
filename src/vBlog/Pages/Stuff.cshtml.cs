using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;
using vBlog.Models;

namespace vBlog.Pages
{
    public class StuffModel : PageModel
    {
        public List<PostSummary> Posts { get; set; }

        public void OnGet()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Posts.xml");
            var xmlDocument = XDocument.Load(filePath);
            Posts = xmlDocument.Descendants("Post")
                .Where(x => (string)x.Element("Category") == "Stuff")
                .Select(x => new PostSummary
                {
                    Title = (string)x.Element("Title"),
                    Url = (string)x.Element("Url"),
                    ImageUrl = (string)x.Element("ImageUrl"),
                    Date = (DateTime)x.Element("Date")
                })
                .OrderByDescending(p => p.Date)
                .ToList();
        }
    }
}
