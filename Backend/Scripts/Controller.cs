using System;
using System.Collections.Generic;
using Backend.Classes;

namespace Buchungssystem_Backend.Scripts
{
    public class Controller
    {
        public User Login(string email, string password)
        {
            
            return null;
        }

        public int Register(string email, string password, string firstname, string lastname, int age)
        {
            return 0;
        }


        public List<Showing> GetShowings()
        {
            return new List<Showing>
    {
                new Showing {},
                new Showing {}
            };
        }


    }
}
