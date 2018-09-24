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
 

    public class StudentV1Controller : ApiController
    {
        static List<StudentV1> students = new List<StudentV1>()
        {
            new StudentV1() { Id = 1, Name = "Tom" },
            new StudentV1() { Id = 2, Name = "Sam" },
            new StudentV1() { Id = 3, Name = "John" }
        };

        //[Route("")]
        //public IEnumerable<Student> Get()
        //{
        //    return students;
        //}
        // [Route("{id:int}")]
        // [Route("{id:int:min(1)}")]
        //  [Route("{id:int:min(1):max(3)}")]

        //[Route("{id:int:range(1,4)}" , Name="GetStudentById")]
        //public Student Get(int id)
        //{
        //    return students.FirstOrDefault(s => s.Id == id);
        //}
         

         

        [Route()]
        public HttpResponseMessage Post(StudentV1 student)
        {
            students.Add(student);
            var response = Request.CreateResponse(HttpStatusCode.Created);
            //response.Headers.Location = new Uri(Request.RequestUri + student.Id.ToString());
            response.Headers.Location = new Uri(Url.Link("GetStudentById", new { id = student.Id }));
            return response;
        }

        //public HttpResponseMessage Get()
        //{
        //    return Request.CreateResponse(students);
        //}

        //public HttpResponseMessage Get(int id)
        //{
        //    var student = students.FirstOrDefault(s => s.Id == id);
        //    if (student == null)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
        //            "Student not found");
        //    }

        //    return Request.CreateResponse(student);
        //}

        [Route("api/v1/students")]
        public IHttpActionResult Get()
        {
            return Ok(students);
        }
        [Route("api/v1/students/{id}")]

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

 