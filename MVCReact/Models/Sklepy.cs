using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCReact.Models
{
    public class Sklepy
    {
        [Key]
        public int Id { get; set; }
        public string Nazwa { get; set; }

        public ICollection<Dane> Danes { get; set; }
       
    }
}
