using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar
{
    public class CarsTypeLogic : BaseLogic
    {
        //Add CarBrand to DB
        public string addCarType(carTypeDTO carType)
        {
            string message = "";
        
            var checkedCarBrand = from c in DB.CarTypes
                          where carType.manufacturer == c.CarManufacturerName &&
                                carType.model == c.CarModelName&&
                                carType.transmission == c.GearTypeName&&
                                carType.productionYear == c.Year
                          select carType.manufacturer;

            if (!checkedCarBrand.Any())
            {
                CarType carTypeToAdd = new CarType
                {  
                    CarManufacturerName = carType.manufacturer,
                    CarModelName = carType.model,
                    GearTypeName = carType.transmission,
                    Year = carType.productionYear,
              // important   //  DailyCost = carType.pricePerDay,
                    DailyLateCost= carType.pricePerDayIfDalay
                };
                DB.CarTypes.Add(carTypeToAdd);
                DB.SaveChanges();
                carType.id = carTypeToAdd.CarTypeID;
                message = "Car Brand successfuly created";
                return message;
            }
            else
            {
                message = "Car Brand with this paramiters is already exist! please choose another name";
                return message;
            }
        }

        ////Get user from DB
        //public UserDTO GetUser(logInDTO loggedUser)
        //{
        //    var user = from u in DB.Users
        //               where loggedUser.userName == u.userName && loggedUser.password == u.userPasword
        //               select new UserDTO
        //               {
        //                    firstName = u.userFirstName,
        //                    lastName = u.userLastName,
        //                    IdOfUser =  u.userID,
        //                    nameOfUser = u.userName,
        //                    dateOfBirth= u.userBirthDate,
        //                    email =u.userEmail,
        //                    gender = u.userGender,
        //                    password = u.userPasword,
        //                    image = u.userImage,
        //                    role = u.userRole
        //               };

        //    if (user.Any())
        //    {
        //        return user.SingleOrDefault();
        //    }
        //    else
        //    {
        //        return new UserDTO
        //        {
        //            nameOfUser = null,
        //            password = null
        //        };
        //    }
        //}

        //public ProductDTO UpdateProduct(ProductDTO product)
        //{
        //    Product productToUpdate = DB.Products
        //        .Where(p => p.ProductID == product.id).SingleOrDefault();

        //    if (productToUpdate == null)
        //        return null;

        //    productToUpdate.ProductName = product.name;
        //    productToUpdate.UnitPrice = product.price;
        //    productToUpdate.UnitsInStock = product.stock;
        //    DB.SaveChanges();
        //    return product;
        //}

        //public void DeleteProduct(int id)
        //{
        //    Product productToDelete = DB.Products
        //        .Where(p => p.ProductID == id).SingleOrDefault();

        //    if (productToDelete != null)
        //    {
        //        DB.Products.Remove(productToDelete);
        //        DB.SaveChanges();
        //    }
        //}

    }
}
