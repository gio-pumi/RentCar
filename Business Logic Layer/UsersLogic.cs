using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar
{
    public class UsersLogic : BaseLogic
    {
        //Add User to DB
        public string AddUser(userDTO user)
        {
            string message = "";

            var checkedUser = from u in DB.Users
                              where user.nameOfUser == u.userName
                              select user.nameOfUser;

            if (!checkedUser.Any())
            {
                User userToAdd = new User
                {
                    userFirstName = user.firstName,
                    userLastName = user.lastName,
                    userID = user.IdOfUser,
                    userName = user.nameOfUser,
                    userBirthDate = user.dateOfBirth,
                    userEmail = user.email,
                    userGender = user.gender,
                    userPasword = user.password,
                    userImage = user.image,
                    userRole = user.role
                };
                DB.Users.Add(userToAdd);
                DB.SaveChanges();
                message = "User successfuly created";
                return message;
            }
            else
            {
                message = "User with name " + user.nameOfUser + " is already exist! please choose another name";
                return message;
            }
        }

        //Get user from DB
        public userDTO GetUser(logInDTO loggedUser)
        {
            var user = from u in DB.Users
                       where loggedUser.userName == u.userName && loggedUser.password == u.userPasword
                       select new userDTO
                       {
                           firstName = u.userFirstName,
                           lastName = u.userLastName,
                           IdOfUser = u.userID,
                           nameOfUser = u.userName,
                           dateOfBirth = u.userBirthDate,
                           email = u.userEmail,
                           gender = u.userGender,
                           password = u.userPasword,
                           image = u.userImage,
                           role = u.userRole
                       };

            if (user.Any())
            {
                return user.SingleOrDefault();
            }
            else
            {
                return new userDTO
                {
                    nameOfUser = null,
                    password = null
                };
            }
        }

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
