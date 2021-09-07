using EFLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace T4._7._2.Controllers
{
    public class RequestController : ApiController
    {
        // GET api/<controller>
        RequestManager requestManager;

        RequestController() {
            requestManager = new RequestManager();
        }
        public IEnumerable<requestInfo> Get()
        {
            return requestManager.GetAllRequestInfo();
        }

        

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]requestInfo request)
        {
            if (!ModelState.IsValid)
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = new { Failed = "Invalid data." } });

            if (CheckRequest(request.MobileNumber))
            {
                DateTime now = DateTime.Now;
                using (var ctx = new RequestsEntities())
                {
                    ctx.requestInfoes.Add(new requestInfo()
                    {
                        MobileNumber = request.MobileNumber,
                        RequestDate = now
                    });

                    ctx.SaveChanges();
                }
            }else
            {
                return this.Request.CreateResponse(HttpStatusCode.Created, new { Message = new { Duplicate = "Mobile number was added before." } });
            }

            return this.Request.CreateResponse(HttpStatusCode.Created, new { Message = new { Success = "Request is Added." } });
        }

        public bool CheckRequest(int MobileNumber)
        {
            IEnumerable<requestInfo> requests = requestManager.GetAllRequestInfo();
            foreach (var request in requests) 
            {
                if (request.MobileNumber == MobileNumber) {
                    return false;
                }
            }

            return true;
        }

       
    }
}