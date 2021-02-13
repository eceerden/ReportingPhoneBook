using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookSide.API.Models.ORM
{
    public class Base
    {
        public int ID { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTime AddDate { get; set; } = DateTime.Now;
    }
}
