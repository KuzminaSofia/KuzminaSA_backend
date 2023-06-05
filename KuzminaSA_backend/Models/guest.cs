using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace KuzminaSA_backend.Models
{
    public class guest
    {
        public int Id { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string happy_b { get; set; }

        internal void Addguest(guest? guest)
        {
            throw new NotImplementedException();
        }


        public guest(int Id, string last_name, string first_name, string happy_b)
        {
            this.Id = Id;
            this.last_name = last_name;
            this.first_name = first_name;
            this.happy_b = happy_b;
        }


    }
}
