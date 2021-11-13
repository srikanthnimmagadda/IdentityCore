using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using IdentityPractice.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityPractice.Pages.HumanResource
{
    [Authorize(Policy = "MustBeHR")]
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<DTO.WeatherForecast> WeatherForecasts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private readonly IHttpClientFactory httpClientFactory;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task OnGet()
        {
            HttpClient httpClient = httpClientFactory.CreateClient("IPWebApi");
            WeatherForecasts = await httpClient.GetFromJsonAsync<List<DTO.WeatherForecast>>("WeatherForecast");
        }
    }
}
