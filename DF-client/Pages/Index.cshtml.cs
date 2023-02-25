using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DF_client.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [ViewData]
        public string RemoteIpAddress { get; set; }

        [ViewData]
        public string OriginUrl  { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

            // Get remote IP address
             RemoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            // Get origin header
           
            OriginUrl = HttpContext.Request.GetEncodedUrl().ToString();

        }
    }
}