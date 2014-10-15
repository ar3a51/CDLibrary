using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using CDLibrary.Common;
using CDLibrary.BL;

namespace CDLibrary.Controllers
{
    public class CDApiController : ApiController
    {
        // GET api/cdapi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/cdapi/5
        public HttpResponseMessage Get(int id, [FromBody]string insertBy)
        {

            HttpResponseMessage message;
            try 
            { 
                CD cdResult = CDRepository.FindCDById(id,insertBy);
                if (cdResult == null)
                    throw new Exception("CD not found");

                message = Request.CreateResponse(HttpStatusCode.OK, cdResult);
            }
            catch(Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }

            return message;
        }

        // POST api/cdapi
        public HttpResponseMessage Post([FromBody]CD cdValue)
        {
            cdValue.insertBy = "me";
            cdValue.updateDate = DateTime.Now;
            cdValue.insertDate = DateTime.Now;

            CDRepository.AddNewCD(cdValue);

            HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.OK);

            return message;
            
        }

        // PUT api/cdapi/5
        public HttpResponseMessage Put([FromBody]CD cdValue)
        {
            HttpResponseMessage message;
            try { 
                Boolean result =  CDRepository.updateCD(cdValue);

                message = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);

            }

             return message;
          

        }

        // DELETE api/cdapi/5
        public void Delete(int id)
        {
        }
    }
}
