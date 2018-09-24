using DemoWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//http://csharp-video-tutorials.blogspot.com/2017/02/web-api-attribute-routing-constraints.html
namespace DemoWebApi.Controllers
{
 

    public class StudentV2Controller : ApiController
    {
        static List<StudentV2> students = new List<StudentV2>()
        {
            new StudentV2() { Id = 1, FirstName = "Tom" , LastName = "Jones" },
            new StudentV2() { Id = 2, FirstName = "Sam" , LastName = "Patric"},
            new StudentV2() { Id = 3, FirstName = "John" , LastName = "Desuja"}
        };





        [Route("api/v2/students")]
        public IHttpActionResult Get()
        {
            return Ok(students);
        }


        [Route("api/v2/students/{id}")]
        public IHttpActionResult Get(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                //return NotFound();
                return Content(HttpStatusCode.NotFound, "Student not found");
            }

            return Ok(student);
        }
         
    }
}

 