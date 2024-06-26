﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

//Custom Modules
using FreshyCartDAL.Models;


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

        //Validating Login ***********************************************
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

        //**************************** Register New Users ********************************
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
    }

}
