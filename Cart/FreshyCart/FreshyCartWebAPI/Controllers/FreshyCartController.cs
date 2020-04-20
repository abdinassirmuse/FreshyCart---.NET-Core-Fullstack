using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//Custom Modules 
using FreshyCartDAL;
using FreshyCartDAL.Models;

namespace FreshyCartWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FreshyCartController : ControllerBase
    {

        FreshyCartRepository repository = new FreshyCartRepository();


        #region ***************** Login Customer ******************************
        [HttpGet]
        public JsonResult UserLogin(string emailId, string password)
        {
            string result;

            try
            {
                result = repository.UserLogin(emailId, password);
            }
            catch (Exception)
            {

                result = null;
            }

            return new JsonResult(result);
        }

        #endregion

        #region ****************** Register ***************************************
        [HttpPost]
        public JsonResult RegisterUser(Models.Users userObj)
        {
            var status = false;

            try
            {
                FreshyCartDAL.Models.Users user = new FreshyCartDAL.Models.Users();

                user.EmailId = userObj.EmailId;
                user.FullName = userObj.FullName;
                user.Password = userObj.Password;

                status = repository.RegisterUser(user);
            }
            catch (Exception)
            {

                status = false;
            }

            return new JsonResult(status);
        }

        #endregion

        #region ************* Get All Products ********************************
        [HttpGet]
        public JsonResult GetAllProducts()
        {
            List<Models.Products> listOfProducts = new List<Models.Products>();
            try
            {
                var productsList = repository.GetAllProducts();
                if (productsList.Any())
                {
                    foreach (var item in productsList)
                    {
                        listOfProducts.Add(new Models.Products()
                        {
                            ProductId = item.ProductId,
                            ProductName = item.ProductName,
                            Price = item.Price,
                            ProductImage = item.ProductImage
                        }
                        );
                    }
                }
            }
            catch (Exception)
            {
                listOfProducts = null;
            }
            return new JsonResult(listOfProducts);
        }

        #endregion

        //public JsonResult GetProductImages()
        //{
        //    List<Models.Products> listOfProducts = new List<Models.Products>();
        //    try
        //    {
        //        var productsList = repository.GetAllProducts();
        //        if (productsList.Any())
        //        {
        //            foreach (var item in productsList)
        //            {
        //                listOfProducts.Add(new Models.Products()
        //                {                 
        //                    ProductImage = item.ProductImage
        //                }
        //                );
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        listOfProducts = null;
        //    }
        //    return new JsonResult(listOfProducts);
        //}


        #region ************************* Get Featured Products **********************************
        [HttpGet]
        public JsonResult GetFeaturedProducts()
        {
            List<Models.FeaturedProducts> listOfProducts = new List<Models.FeaturedProducts>();
            try
            {
                var productsList = repository.GetFeaturedProducts();
                if (productsList.Any())
                {
                    foreach (var item in productsList)
                    {
                        listOfProducts.Add(new Models.FeaturedProducts()
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Fpimage = item.Fpimage
                        }
                        );
                    }
                }
            }
            catch (Exception)
            {
                listOfProducts = null;
            }
            return new JsonResult(listOfProducts);
        }
        #endregion


        #region ****************** Get SlideShow Images*************************************************
        [HttpGet]
        public JsonResult GetSlideshow()
        {
            List<Models.SlideShow> listofImages = new List<Models.SlideShow>();
            try
            {
                var slideshowList = repository.GetSlideShow();
                if (slideshowList.Any())
                {
                    foreach (var item in slideshowList)
                    {
                        listofImages.Add(new Models.SlideShow()
                        {
                           Id = item.Id,
                           Name = item.Name,
                           SlideImage = item.SlideImage
                        }
                        );
                    }
                }
            }
            catch (Exception)
            {
                listofImages = null;
            }
            return new JsonResult(listofImages);
        }

        #endregion


        #region ************************ AddProductsToCart ************************
        [HttpPost]
        public JsonResult AddProductToCart(Models.Cart cartObj)
        {
            var status = -1;
            try
            {

                FreshyCartDAL.Models.Cart cart = new FreshyCartDAL.Models.Cart();

                cart.EmailId = cartObj.EmailId;
                cart.ProductId = cartObj.ProductId;
                cart.ProductName = cartObj.ProductName;
                cart.ProductImage = cartObj.ProductImage;

                status = repository.AddProductToCart(cart);
            }
            catch (Exception)
            {
                status = -1;
            }
            return new JsonResult(status);
        }
        #endregion

        #region *********************** Get Product In Cart with Price ****************************
        [HttpGet]
        //Functions
        public JsonResult GetCartProducts(string emailId)
        {
            List<Models.CartProducts> listOfCartProd = new List<Models.CartProducts>();
            try
            {
                var cartList = repository.GetCartProducts(emailId);
                if (cartList.Any())
                {
                    foreach (var item in cartList)
                    {
                        listOfCartProd.Add(new Models.CartProducts()
                        {
                            ProductId = item.ProductId,
                            ProductName = item.ProductName,
                            Price = item.Price,
                            Quantity = item.Quantity,
                            ProductImage = item.ProductImage
                        }
                        );
                    }
                }
            }
            catch (Exception)
            {
                listOfCartProd = null;
            }
            return new JsonResult(listOfCartProd);

        }

        #endregion

        #region ****************** Update Cart Products ******************************
        [HttpPut]
        public JsonResult UpdateCartProducts(Cart cartObj)
        {
            bool status = false;
            try
            {
               
                status = repository.UpdateCartProducts(cartObj);
            }
            catch (Exception)
            {
                status = false;
            }
            return new JsonResult(status);
        }

        #endregion

        #region ****************** Delete Cart Products ******************************
        [HttpDelete]
        public JsonResult DeleteFromCart(Cart cartObj)
        {
            bool status = false;
            try
            {
                status = repository.DeleteFromProduct(cartObj);

            }
            catch (Exception)
            {

                status = false;
            }

            return new JsonResult(status);
        }
        #endregion


        // POST: api/FreshyCart
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/FreshyCart/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
