using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

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
        public List<TimelineEvent> TimelineEvents { get; set; }

        public void OnGet()
        {
            TimelineEvents = new List<TimelineEvent>
            {
                // NOTE: You can add HTML in the Description field, make sure to keep on one line to avoid breaking the layout.
                new TimelineEvent
                {
                    Year = "2016",
                    Description = "Florian. M (founder of v38armageddon) created Vincent OS App, a software who simulate his operating system.",
                    Side = "left"
                },
                new TimelineEvent
                {
                    Year = "2017",
                    Description = "Florian. M started building his community with his YouTube channel and Discord server.",
                    Side = "right"
                },
                new TimelineEvent
                {
                    Year = "2020",
                    Description = "Florian. M and his community decided to create a really new operating system, the goal are this operating system was free for everyone and easy to use by everyone.",
                    Side = "left"
                },
                new TimelineEvent
                {
                    Year = "2022",
                    Description = "The website: <a href=\"https://vincent-os.v38armageddon.net\">vincent-os.v38armageddon.net</a> was created. This website was the first website of v38armageddon.<br/>In the same year, v38armageddon aquired a licence for publishing apps in the Microsoft Store for Windows and Xbox.<br/>The first Windows Application after Vincent OS App is: WebSM.",
                    Side = "right"
                },
                new TimelineEvent
                {
                    Year = "2023",
                    Description = "The domain name has been changed from: v38armageddon.cf to v38armageddon.net.<br/>In the same year, a new game has developped: D.O.T, a platformer-puzzle game. There is also a new game server: ArmaLand, a Team Fortress 2 server.",
                    Side = "left"
                },
                new TimelineEvent
                {
                    Year = "2024",
                    Description = "On 2024-11-26, the official <a href=\"https://store.steampowered.com/app/3357970/DOT/\">Steam page for D.O.T</a> has been released! It marked as a new step and the default platform for all games made by v38armageddon.",
                    Side = "right"
                },
                new TimelineEvent
                {
                    Year = "2025",
                    Description = "On 2025-05-22, the Demo version of D.O.T has been released, giving you a first taste of the game. On 2025-07-05, Vincent OS 1.0 was released in Open Beta, after 9 years of developments, it was worth the wait no?",
                    Side = "left"
                }
            };
        }
    }
}
