using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Text;
using Newtonsoft.Json.Linq;

namespace FeedIt.Controllers
{
    public class HomeController : ApiController
    {
        [Route("")]
        public IHttpActionResult Get()
        {
            var stream = this.GetType().Assembly.GetManifestResourceStream("FeedIt.openapi.json");

            var content = new StreamContent(stream);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            return new ResponseMessageResult(new HttpResponseMessage() { Content = content });
        }

    }
}