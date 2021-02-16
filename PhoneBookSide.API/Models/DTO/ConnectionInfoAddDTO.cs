using PhoneBookSide.API.Models.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookSide.API.Models.DTO
{
    public class ConnectionInfoAddDTO
    {
        public string Phone { get; set; }

        public string Email { get; set; }
        public string Location { get; set; }

        public string context { get; set; }

        public int PersonID { get; set; }
        [ForeignKey("PersonID")]
        public Person person { get; set; }
    }
}
