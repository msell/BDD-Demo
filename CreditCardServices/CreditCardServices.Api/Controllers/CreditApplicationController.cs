using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CreditCardServices.Api.Controllers
{
    public class CreditApplicationController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            return Ok(id);
        }
    }
}
