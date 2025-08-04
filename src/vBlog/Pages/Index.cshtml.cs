using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using System.Text.RegularExpressions;
using vBlog.Models;

namespace vBlog.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IWebHostEnvironment env)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
