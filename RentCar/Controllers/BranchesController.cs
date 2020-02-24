using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RentCar

{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/branches")]

    public class BranchesController : ApiController
    {
        private BranchLogic logic = new BranchLogic();

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GeBranches(branchDTO branch)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,
                        ErrorsManager.GetErrors(ModelState));
                }

                List<branchDTO> getranch = logic.getBranch();
                return Request.CreateResponse(HttpStatusCode.OK, getranch);
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
