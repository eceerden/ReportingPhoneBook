using PhoneBookSide.API.Models.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookSide.API.Models.DTO
{
    public class DetailedPersonDTO
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Company { get; set; }

        public List<ConnectionInfo> details { get; set; }
    }
}
