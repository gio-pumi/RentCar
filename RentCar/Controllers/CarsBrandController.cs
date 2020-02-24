using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RentCar.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/carBrands")]

    public class CarsBrandController : ApiController
    {
        private CarsTypeLogic logic = new CarsTypeLogic();

        [HttpPost]
        [Route("")]
        public HttpResponseMessage AddCarBrand(carTypeDTO carBrand)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,
                        ErrorsManager.GetErrors(ModelState));
                }

                string addedCarBrand = logic.addCarType(carBrand);
                return Request.CreateResponse(HttpStatusCode.Created, addedCarBrand);
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
