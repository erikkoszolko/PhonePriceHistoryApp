using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCReact.Models
{

    public class Marka
    {


        [Key]
        public int Id { get; set; }
        public string Nazwa { get; set; }
        
        public Marka(string nazwa)
        {
            this.Nazwa = nazwa;
        }


    }
}
