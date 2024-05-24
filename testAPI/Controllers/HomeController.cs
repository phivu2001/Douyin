using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using testAPI.Models;

namespace testAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var apiUrl = "https://api.amaicontent.com/douyin-contents?page=1&per_page=20";
            var client = _httpClientFactory.CreateClient();

            // Thêm các header cần thiết
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("authorization", "JWT eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6MjAzLCJyb2xlX2lkIjoyLCJlbWFpbCI6InBoaWNhdW1lQGdtYWlsLmNvbSIsInBhc3N3b3JkIjoiJDJhJDEwJHJDYVhmOGh4ak9lLk85NFZwaXVHRU9XRVFaQnprOExaQUQuYVJ5M2VCVGxpMGFOYUFSWkI2IiwiZnVsbF9uYW1lIjpudWxsLCJ1c2VybmFtZSI6InBoaWNhdW1lIiwidG9rZW4iOiJleUpoYkdjaU9pSklVekkxTmlJc0luUjVjQ0k2SWtwWFZDSjkuZXlKbGJXRnBiQ0k2SW5Cb2FXTmhkVzFsUUdkdFlXbHNMbU52YlNJc0luQmhjM04zYjNKa0lqb2lKREpoSkRFd0pISkRZVmhtT0doNGFrOWxMazg1TkZad2FYVkhSVTlYUlZGYVFucHJPRXhhUVVRdVlWSjVNMlZDVkd4cE1HRk9ZVUZTV2tJMklpd2lhV0YwSWpveE56RTBPRGMzTlRReExDSmxlSEFpT2pFM01UYzBOamsxTkRGOS42clVtUkkzeTluSkpscS0yaWVWYWRQZ3k1a0sydS0wUjM0ZDNNcDcwR0VFIiwiYXZhdGFyIjpudWxsLCJyZWZfY29kZSI6IjNlNTBhNzQxY2UiLCJjb2luIjowLCJhY2NvdW50X2NvdW50IjowLCJ0YXJnZXRfY291bnQiOjAsIndvcmtzcGFjZV9jb3VudCI6MSwicmV3YXJkX21vbmV5IjowLCJ0b2tlbl9leHBpcmVkX2F0IjpudWxsLCJwYWNrYWdlX2V4cGlyZWRfYXQiOiIyMDI0LTA1LTEyVDAyOjUyOjIxLjAwMFoiLCJzZW5kX2VtYWlsX2F0IjoiMjAyNC0wNS0wNVQwMjo1MjoyMS4wMDBaIiwidmVyaWZpZWRfYXQiOm51bGwsImJhbmtfbmFtZSI6bnVsbCwiYmFua19icmFuY2giOm51bGwsImJhbmtfbnVtYmVyIjpudWxsLCJiYW5rX2FjY291bnQiOm51bGwsInNvY2tldF9rZXkiOm51bGwsInN0YXR1cyI6bnVsbCwicmVmX2NsaWNrcyI6MCwiYm91Z2h0IjpmYWxzZSwiY3JlYXRlZEF0IjoiMjAyNC0wNS0wNVQwMjo1MjoyMS4wMDBaIiwidXBkYXRlZEF0IjoiMjAyNC0wNS0wNVQwMjo1MjoyMS4wMDBaIiwiZGVsZXRlZEF0IjpudWxsLCJwYXJlbnRfaWQiOm51bGwsImlhdCI6MTcxNDg3NzU0NywiZXhwIjoxNzE3NDY5NTQ3fQ.V3lzWwXLIsMk39kR4qXL20hBDQTjgYWHKpzEdcb-gNw");
            client.DefaultRequestHeaders.Add("browser_key", "b3f39f76-4bd4-4ab0-a9c3-3abf29ee56d8");


            var response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var apiResult = JsonConvert.DeserializeObject<APIModel>(responseData);

                return View(apiResult);
            }
            else
            {
                return View("Error");
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
