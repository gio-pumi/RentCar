using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar
{
    public class CarsLogic : BaseLogic
    {
        //Add Car to DB
        public string AddCar(carDTO car)
        {
            string message = "";

            var checkedCar = from c in DB.CarFleets
                             where car.number == c.CarNumber 
                             select car.number;

            if (!checkedCar.Any())
            {
                
                CarFleet carToAdd = new CarFleet
                {  
                    CarTypeID = car.typeId,
                    CarMileage = car.mileage,
                    CarImage = car.image,
                    IsOK2Rent= car.properForRent,
                    CarAvilable = car.avilable,
                    CarNumber = car.number,
                    CarBranchPlace= car.branchPlace
                };
                DB.CarFleets.Add(carToAdd);
                DB.SaveChanges();
                message = "Car successfuly created";
                return message;
            }
            else
            {
                message = "Car with this paramiters is already exist! please choose another parameters";
                return message;
            }
        }

        //Get All Cars 

        public List<displayCarDTO> GetAllCars()
        {
            var allCars = from c in DB.CarFleets
                    select new displayCarDTO
                    { 
                        number = c.CarNumber,
                        mileage = c.CarMileage,
                        image = c.CarImage,
                        properForRent = c.IsOK2Rent,
                        avilable = c.CarAvilable,
                        branchPlace = c.CarBranchPlace,
                        manufacturer = c.CarType.CarManufacturerName,
                        model = c.CarType.CarModelName,
                        transmission = c.CarType.GearTypeName,
                        productionYear = c.CarType.Year,
                        pricePerDay = c.CarType.DailyCost,
                        pricePerDayIfDalay = c.CarType.DailyLateCost
                    };

            return allCars.ToList();
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
