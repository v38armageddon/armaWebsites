using System.IO;
using Markdig;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace vBlog.Pages
{
    public class PostModel : PageModel
    {
        public string MarkdownHtml { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }

        public void OnGet(string slug)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "article", $"{slug}.md");
            if (System.IO.File.Exists(filePath))
            {
                var markdownContent = System.IO.File.ReadAllText(filePath);
                var lines = markdownContent.Split('\n');
                var titleLine = lines.FirstOrDefault(line => line.TrimStart().StartsWith("# "));
                if (!string.IsNullOrEmpty(titleLine))
                {
                    PostTitle = titleLine.TrimStart().Substring(2).Trim();
                }
                PostContent = Markdown.ToHtml(markdownContent);
            }
            else
            {
                MarkdownHtml = "<p>Post not found.</p>";
            }
        }
    }
}
