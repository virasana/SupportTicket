//using System.Collections.Generic;
//using InterfacesLib;
//using Microsoft.AspNetCore.Cors;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using ST.SharedEntities.Models;

//namespace ST.Web.ApiControllers
//{
//    // TODO: Enable CORS [EnableCors(origins: "*", headers: "*", methods: "*")]
//    public class TicketsController : Controller
//    {
//        private readonly ISTService<ISTRepo> _stService;

//        public TicketsController(ISTService<ISTRepo> stService)
//        {
//            _stService = stService;
//        }

//        // GET: api/Tickets
//        public IActionResult GetTicket()
//        {
//            var result = _stService.GetClosedTickets();

//            return Ok(result);
//        }

//        [Route("api/Products")]
//        public IActionResult GetProducts()
//        {
//            var result = _stService.GetProducts();
//            return Ok(result);
//        }

//        [Route("api/Severities")]
//        public IActionResult GetSeverities()
//        {
//            var result = _stService.GetSeverities();
//            return Ok(result);
//        }

//        // GET: api/Tickets/5
//        [HttpGet("{id}", Name = "GetTicket")]
//        public IActionResult GetTicket(int id)
//        {
//            Ticket ticket = _stService.GetTicket(id);

//            if (ticket == null)
//            {
//                return NotFound();
//            }

//            return Ok(ticket);
//        }

//        [Route("api/tickets/add")]
//        [HttpPost]
//        public IActionResult PostTicket(Ticket ticket)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//            var result = _stService.AddTicket(ticket);
//            return CreatedAtRoute("GetTicket", new { id=result.TicketId }, result);
//        }
//    }
//}