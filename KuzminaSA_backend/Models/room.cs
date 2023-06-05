using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;


namespace KuzminaSA_backend.Models
{
    public class room
    {
        public int Id { get; set; }
        public int capacity { get; set; } // вместимость
        public string desc { get; set; } //краткое описание
        public string guest { get; set; }
        public int price { get; set; }


        public room(int Id, int capacity, string desc, string guest, int price)
        {
            this.Id = Id;
            this.capacity = capacity;
            this.desc = desc;
            this.guest = guest;
            this.price = price;
        }
    }
}
