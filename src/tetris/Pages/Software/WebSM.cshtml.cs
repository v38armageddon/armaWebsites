using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace tetris.Pages
{
    public class WebSMModel : PageModel
    {
        public void OnGet()
        {
        }
    }

    public class MicrosoftStoreReview
    {
        public async Task<MicrosoftStoreReviewData> GetReviews(string productId)
        {
            string url = $"https://storeedgefd.dsx.mp.microsoft.com/v10.0/product/{productId}/reviews?market=fr-FR";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    MicrosoftStoreReviewData reviewData = JsonConvert.DeserializeObject<MicrosoftStoreReviewData>(jsonResponse);
                    return reviewData;
                }
                else
                {
                    // Handle error
                    return null;
                }
            }
        }
    }

    public class MicrosoftStoreReviewData
    {
        public MicrosoftStoreReviewDataItem[] Items { get; set; }
    }

    public class MicrosoftStoreReviewDataItem
    {
        public string ProductId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        // Add more properties as needed
    }
}
