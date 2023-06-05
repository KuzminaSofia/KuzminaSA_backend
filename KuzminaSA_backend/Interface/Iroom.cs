using KuzminaSA_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace KuzminaSA_backend.Interface
{
    public interface Iroom
    {
        IEnumerable<room> room { get; }
        room getObjectBook(int roomId);
    }
}
