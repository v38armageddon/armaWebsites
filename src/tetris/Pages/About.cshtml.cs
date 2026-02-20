using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace tetris.Pages
{
    public class TimelineEvent
    {
        public required string Year { get; set; }
        public required string Description { get; set; }
        public required string Side { get; set; } // "left" or "right" for the CSS part, don't put anything else here!
    }

    public class AboutModel : PageModel
    {
        private readonly IWebHostEnvironment _env;

        // Initialized to avoid null in views
        public List<TimelineEvent> TimelineEvents { get; set; } = new List<TimelineEvent>();

        public AboutModel(IWebHostEnvironment env)
        {
            _env = env;
        }

        public void OnGet()
        {
            var historyPath = Path.Combine(_env.WebRootPath ?? string.Empty, "History.xml");

            if (!System.IO.File.Exists(historyPath))
            {
                TimelineEvents = new List<TimelineEvent>();
                return;
            }

            try
            {
                var doc = XDocument.Load(historyPath);
                TimelineEvents = doc.Root?
                    .Elements("Year")
                    .Select(y =>
                    {
                        var year = (string?)y.Attribute("Time") ?? string.Empty;
                        var side = (string?)y.Attribute("Side") ?? "left";
                        var textEl = y.Element("Text");
                        var desc = textEl != null
                            ? string.Concat(textEl.Nodes().Select(n => n.ToString()))
                            : string.Empty;

                        // Collapse whitespace/newlines to single spaces to avoid layout breaks
                        desc = Regex.Replace(desc, @"\s+", " ").Trim();

                        return new TimelineEvent
                        {
                            Year = year,
                            Description = desc,
                            Side = side
                        };
                    })
                    .ToList() ?? new List<TimelineEvent>();
            }
            catch
            {
                // On any parse/load error, return empty timeline to avoid crashing the page.
                TimelineEvents = new List<TimelineEvent>();
            }
        }
    }
}
