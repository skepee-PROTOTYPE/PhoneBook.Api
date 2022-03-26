using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.CodeAnalysis.Options;
using Microsoft.AspNetCore.Authorization;

namespace PhoneBook.Client.Pages
{
    //[Authorize]
    public class PhoneBookModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public List<PhoneBookNumber> PhoneNumbers { get; set; }

        public PhoneBookModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task OnGetAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("APIClient");
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/phonebook");
            var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            using var responseStream = await response.Content.ReadAsStreamAsync();
            PhoneNumbers = await JsonSerializer.DeserializeAsync<List<PhoneBookNumber>>(responseStream, options);
        }
    }
}