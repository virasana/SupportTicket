using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc.Rendering;
using ST.SharedEntities.Models;

namespace ST.Web.ViewModels
{
    public class STAddTicketViewModel
    {
        public Ticket Ticket { get; set; }
        public IEnumerable<SelectListItem> Severities { get; set; }

        public IEnumerable<SelectListItem> Products{ get; set; }
    }
}