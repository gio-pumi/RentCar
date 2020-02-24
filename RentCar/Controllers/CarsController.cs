using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;

namespace RentCar.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/cars")]

    public class CarsController : ApiController
    {
        private CarsLogic logic = new CarsLogic();

        [HttpPost]
        [Route("")]
        public HttpResponseMessage AddCar(carDTO car)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,
                        ErrorsManager.GetErrors(ModelState));
                }

                string addedCar = logic.AddCar(car);

                return Request.CreateResponse(HttpStatusCode.Created, addedCar);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(
                    HttpStatusCode.InternalServerError,
                        ErrorsManager.GetInnerMessage(ex));
            }
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage getAllCars()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,
                        ErrorsManager.GetErrors(ModelState));
                }

                List<displayCarDTO> getAllCars = logic.GetAllCars();
                return Request.CreateResponse(HttpStatusCode.OK, getAllCars);
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
