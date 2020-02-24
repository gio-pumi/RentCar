using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RentCar

{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/users")]

    public class UsersController : ApiController
    {
        private UsersLogic logic = new UsersLogic();

        [HttpPost]
        [Route("login")]
        public HttpResponseMessage GetUser(logInDTO logIn)
        {
            try
            {
                userDTO userFound = logic.GetUser(logIn);
                return Request.CreateResponse(HttpStatusCode.OK, userFound);
             }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(
                    HttpStatusCode.InternalServerError,
                        ErrorsManager.GetInnerMessage(ex));
            }
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage AddProduct(userDTO user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,
                        ErrorsManager.GetErrors(ModelState));
                }

                string addedProduct = logic.AddUser(user);
                return Request.CreateResponse(HttpStatusCode.Created, addedProduct);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(
                    HttpStatusCode.InternalServerError,
                        ErrorsManager.GetInnerMessage(ex));
            }
        }

        //[HttpPut]
        //[Route("{id}")]
        //public HttpResponseMessage UpdateProduct(int id, ProductDTO product)
        //{
        //    try
        //    {
        //        // Route-עדכון קוד המוצר לפי מה שנשלח ב
        //        product.id = id;

        //        // עדכון המוצר במסד הנתונים
        //        ProductDTO updatedProduct = logic.UpdateProduct(product);

        //        // 404 אם לא קיים מוצר כזה - החזרת
        //        if (updatedProduct == null)
        //            return Request.CreateResponse(HttpStatusCode.NotFound);

        //        // מוצר קיים - החזר 200
        //        return Request.CreateResponse(HttpStatusCode.OK, updatedProduct);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(
        //            HttpStatusCode.InternalServerError,
        //                ErrorsManager.GetInnerMessage(ex));
        //    }
        //}

        //[HttpDelete]
        //[Route("{id}")]
        //public HttpResponseMessage DeleteProduct(int id)
        //{
        //    try
        //    {
        //        logic.DeleteProduct(id);
        //        return Request.CreateResponse(HttpStatusCode.NoContent);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(
        //            HttpStatusCode.InternalServerError,
        //                ErrorsManager.GetInnerMessage(ex));
        //    }
        //}
    }
}
