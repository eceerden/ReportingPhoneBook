using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookSide.API.Models.ORM
{
    public class Base
    {
        public int ID { get; set; }

        private bool _isdeleted = false;
        public bool isdeleted
        
        { 
            get
            {return _isdeleted; }
            set {isdeleted = value; }
        
        }
    }
}
