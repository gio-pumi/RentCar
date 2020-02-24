using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RentCar.Controllers
{

    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/uploadImage")]

    public class CUploadImageController : ApiController
    {
        private CarsLogic logic = new CarsLogic();

        [HttpPost]
        [Route("")]
        public HttpResponseMessage AddImage()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,
                        ErrorsManager.GetErrors(ModelState));
                }

                var httpRequest = HttpContext.Current.Request;

                //Upload image
                var postedFile = httpRequest.Files["image"];

                // Create a unique file name: 
                string fileName = Guid.NewGuid() + ".jpg";

                // Find the entire path to the uploads directory on server: 
                string filePath = HttpContext.Current.Server.MapPath("~/Images/" + fileName);

                //Save image
                postedFile.SaveAs(filePath);

                return Request.CreateResponse(HttpStatusCode.Created, fileName);
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
