//using System;
//using Microsoft.AspNetCore.Cors;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace ST.Web.ApiControllers
//{
//    // TODO - Enable Cors [EnableCors(origins: "*", headers: "*", methods: "*")]
//    public class StatusController : Controller
//    {
//        public StatusController()
//        {
//        }

//        [HttpGet("{id}", Name = "GetStatus")]
//        public IActionResult GetStatus(int id)
//        {
//            var status = STSession.Status;

//            if (string.IsNullOrEmpty(status))
//            {
//                return NotFound();
//            }

//            return Ok(status);
//        }


//        [HttpPost]
//        [Route("api/status")]
//        public IActionResult Update([FromBody] string status)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            STSession.Status = status; // Won't work because we don't have session in a WebAPI call!
//            var result = status;
//            return CreatedAtRoute("GetStatus", result);
//        }
//    }

//    public static class STSession
//    {
//        public static string Status
//        {
//            get
//            {
//                // TODO - Should not have any session state in the API
//                // To demo session state, put it in the Web Controllers
//                var result = "Deprecated"; // HttpContext.Current.Session["Status"] == null ? "Status Unknown" : HttpContext.Current.Session["Status"].ToString();
//                return result;
//            }

//            set
//            {
//                // TODO - fix the session state
//                if (value == null) throw new ArgumentNullException(nameof(value));
//                // HttpContext.Current.Session["Status"] = value;
//            }
//        }
//    }
//}