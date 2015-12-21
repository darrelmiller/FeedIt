using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace FeedIt.Controllers
{
    public class HomeController : ApiController
    {
        [Route("")]
        public IHttpActionResult Get()
        {
            return new ResponseMessageResult(new HttpResponseMessage() { Content = new StringContent("Welcome to FeedIt!") });
        }
    }
}