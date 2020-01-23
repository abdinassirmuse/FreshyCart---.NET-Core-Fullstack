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
            //User Model Mapper
            CreateMap<Users, Models.Users>();
            CreateMap<Models.Users, Users>();
        }
    }
}
