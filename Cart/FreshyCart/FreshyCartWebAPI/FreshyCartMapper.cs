using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Custom Modules
using FreshyCartDAL.Models;

namespace FreshyCartWebAPI
{
    public class FreshyCartMapper : Profile
    {
        public FreshyCartMapper()
        {
            //Login Mapper
            CreateMap<Users, Models.Users>();
            CreateMap<Models.Users, Users>();

            //Product Mapper
            CreateMap<Products, Models.Products>();
            CreateMap<Models.Products, Products>();

            //Featured Products Mapper
            CreateMap<Products, Models.Products>();

            //SlideShow Mapper
            CreateMap<Products, Models.Products>();

            //CART Mapper
            CreateMap<Cart, Models.Cart>();
            CreateMap<Models.Cart, Cart>();
        }
    }
}
