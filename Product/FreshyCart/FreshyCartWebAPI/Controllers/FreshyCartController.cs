using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//Custom Modules 
using FreshyCartDAL;

namespace FreshyCartWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FreshyCartController : ControllerBase
    {

        FreshyCartRepository repository = new FreshyCartRepository();


        //Login Customer **********************************************
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

        //Register **************************************************
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

        //Get All Products *************************************************
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

        


        //Get Featured Products*************************************************
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


        // GET: api/FreshyCart/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

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
