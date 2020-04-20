using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

//Custom Modules
using FreshyCartDAL;
using FreshyCartDAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace FreshyCartDAL
{
    public class FreshyCartRepository
    {
        private FreshyCartDBContext context { get; set; }

        public FreshyCartRepository()
        {
            this.context = new FreshyCartDBContext();
        }

        public FreshyCartRepository(FreshyCartDBContext context)
        {
            this.context = context;
        }

        #region ***********************Validating Login *********************************
        public string UserLogin(string emailId, string password)
        {
            string result = "";
            try
            {
                var userObj = (from c in context.Users
                                   where c.EmailId == emailId && c.Password == password
                                   select c).FirstOrDefault<Users>();
                if (userObj != null)
                {
                    result = userObj.FullName;
                }
                else
                {
                    result = "Invalid credentials";
                }
            }
            catch (Exception)
            {

                result = null;
            }

            return result;
        }
        #endregion

        #region **************************** Register New Users ********************************
        public bool RegisterUser(Users userObj)
        {
            bool isUserRegistered = false;
            try
            {
                context.Users.Add(userObj);
                context.SaveChanges();

                isUserRegistered = true;
            }
            catch (Exception)
            {

                isUserRegistered = false;
            }

            return isUserRegistered;
        }
        #endregion

        #region ************************** Get All Products *******************************
        public List<Products> GetAllProducts()
        {
            List<Products> listOfProducts = null;
            try
            {
                listOfProducts = (from p in context.Products
                               select p).ToList<Products>();
            }
            catch (Exception)
            {
                listOfProducts = null;
            }
            return listOfProducts;
        }
        #endregion


        #region **************Get Featured Products***************************
        public List<FeaturedProducts> GetFeaturedProducts()
        {
            List<FeaturedProducts> listOfProducts = null;
            try
            {
                listOfProducts = (from p in context.FeaturedProducts
                                  select p).ToList<FeaturedProducts>();
            }
            catch (Exception)
            {
                listOfProducts = null;
            }
            return listOfProducts;
        }
        #endregion

        #region ******************Get SlideShow Images*****************************
        public List<SlideShow> GetSlideShow()
        {
            List<SlideShow> listOfProducts = null;
            try
            {
                listOfProducts = (from p in context.SlideShow
                                  select p).ToList<SlideShow>();
            }
            catch (Exception)
            {
                listOfProducts = null;
            }
            return listOfProducts;
        }
        #endregion

        #region ******************* AddProductToCart ***********************
        public int AddProductToCart(Cart cartObj)
        {
            int returnvalue = -1;
            try
            {

                returnvalue = context.Database.ExecuteSqlCommand("sp_AddProductToCart @ProductId, @EmaildId, @ProductName, @ProductImage ",
                          new System.Data.SqlClient.SqlParameter("@ProductId", cartObj.ProductId),
                          new System.Data.SqlClient.SqlParameter("@EmaildId", cartObj.EmailId),
                          new System.Data.SqlClient.SqlParameter("@ProductName", cartObj.ProductName),
                          new System.Data.SqlClient.SqlParameter("@ProductImage", cartObj.ProductImage));
            }
            catch (Exception)
            {
                returnvalue = -1;
            }
            return returnvalue;
        }

        #endregion

        #region *********************** Get Product In Cart with Price ****************************

        //Functions
        public List<CartProducts> GetCartProducts(string emailId)
        {
            List<CartProducts> lstProduct = null;
            try
            {
                SqlParameter prmCategoryId = new SqlParameter("@EmailId", emailId);
                lstProduct = context.CartProducts
                                    .FromSql("SELECT * FROM dbo.fn_FetchCartProductByEmailId(@EmailId)", prmCategoryId)
                                    .ToList();
            }
            catch (Exception)
            {
                lstProduct = null;
            }
            return lstProduct;
        }

        #endregion

        #region ****************** Update Cart Products ******************************
        public bool UpdateCartProducts(Cart cartObj)
        {
            bool status = false;

            Cart cartproduct = null;
            try
            {

                cartproduct = (from cart in context.Cart 
                               where cart.ProductId == cartObj.ProductId && cart.EmailId == cartObj.EmailId
                               select cart).FirstOrDefault<Cart>();
                if (cartproduct != null)
                {
                    cartproduct.ProductId = cartObj.ProductId;
                    cartproduct.EmailId = cartObj.EmailId;
                    cartproduct.ProductName = cartObj.ProductName;
                    cartproduct.ProductImage = cartObj.ProductImage;
                    cartproduct.Quantity = cartObj.Quantity;
                    context.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        #endregion

        #region ****************** Delete Cart Products ******************************
        public bool DeleteFromProduct(Cart cartObj)
        {
            bool status = false;
            try
            {
                var prodInCart = (from p in context.Cart
                                  where p.ProductId == cartObj.ProductId && p.EmailId == cartObj.EmailId
                                  select p).FirstOrDefault<Cart>();

                context.Remove(prodInCart);
                context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {

                status = false;
            }
            return status;
        }

        #endregion


    }

}
