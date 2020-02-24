using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RentCar.Controllers
{
        [EnableCors("*", "*", "*")]
        [RoutePrefix("api/searchCar")]

        public class SearchCarController : ApiController
        {
            private SearchCarLogic logic = new SearchCarLogic();

            [HttpPost]
            [Route("")]
            public HttpResponseMessage SearchCar(SearchCarDTO searchedCar)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest,
                            ErrorsManager.GetErrors(ModelState));
                    }

                List<displayCarDTO> allAvlableCars = logic.SearchCar(searchedCar);
                    return Request.CreateResponse(HttpStatusCode.OK, allAvlableCars);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(
                        HttpStatusCode.InternalServerError,
                            ErrorsManager.GetInnerMessage(ex));
                }
            }
        }
}
