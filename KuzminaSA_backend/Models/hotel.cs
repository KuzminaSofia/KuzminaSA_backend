using KuzminaSA_backend;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Text.Json;
using static System.Reflection.Metadata.BlobBuilder;

namespace KuzminaSA_backend.Models
{
    public class hotel
    {
        public int id { get; set; }
        public IList<guest>? guest { get; set; }
        public IList<room>? room { get; set; }

        public hotel()
        {
            room = new List<room>();
            guest = new List<guest>();
        }

        public hotel(IList<guest>? guest, IList<room>? room)
        {
            this.id = id;
            this.guest = guest;
            room = room;
        }



    }
}

   