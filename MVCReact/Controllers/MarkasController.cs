using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCReact.Data;
using MVCReact.Models;
using Newtonsoft.Json;

namespace MVCReact.Controllers
{
    public class MarkasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public string Nazwa { get; private set; }

        public MarkasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Markas
        [HttpGet]
        public string Index()
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(_context.Markas.OrderBy(x => x.Nazwa));
            return JSONString;
        }

        [HttpGet]
        public string Delete(int id)
        {
            string x;
            var deleteOrderDetails =
             from details in _context.Markas
             where details.Id == id
             select details;

            foreach (var detail in deleteOrderDetails)
            {
                _context.Markas.Remove(detail);
            }
            try
            {
                _context.SaveChanges();
                x = "ok";
            }
            catch (Exception e)
            {
                x = "error";
                // Provide for exceptions.
            }
            return x;
        }
        [HttpGet]
        public string Create(string nazwa_form)
        {
            Marka m = new Marka(
                    Nazwa = nazwa_form
                );
            _context.Markas.Add(m);
            _context.SaveChanges();            
            return "added";
        }
    }

}
