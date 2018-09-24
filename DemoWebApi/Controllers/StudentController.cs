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
    [RoutePrefix("api/students")]

    public class StudentsController : ApiController
    {
        static List<Student> students = new List<Student>()
        {
            new Student() { Id = 1, Name = "Tom" },
            new Student() { Id = 2, Name = "Sam" },
            new Student() { Id = 3, Name = "John" }
        };

        [Route("")]
        public IEnumerable<Student> Get()
        {
            return students;
        }
      // [Route("{id:int}")]
      // [Route("{id:int:min(1)}")]
      //  [Route("{id:int:min(1):max(3)}")]

        //[Route("{id:int:range(1,4)}" , Name="GetStudentById")]
        //public Student Get(int id)
        //{
        //    return students.FirstOrDefault(s => s.Id == id);
        //}
        [Route("{id}/courses")]
        public IEnumerable<string> GetStudentCourses(int id)
        {
            if (id == 1)
                return new List<string>() { "C#", "ASP.NET", "SQL Server" };
            else if (id == 2)
                return new List<string>() { "ASP.NET Web API", "C#", "SQL Server" };
            else
                return new List<string>() { "Bootstrap", "jQuery", "AngularJs" };
        }



        [Route("{name:alpha}")]
        public Student Get(string name)
        {
            return students.FirstOrDefault(s => s.Name.ToLower() == name.ToLower());
        }

        [Route()]
        public HttpResponseMessage Post(Student student)
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


        //public IHttpActionResult Get()
        //{
        //    return Ok(students);
        //}

        [Route("{id:int:range(1,14)}", Name = "GetStudentById")]
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


        [Route("~/api/teachers")]

        public IEnumerable<Teacher> GetTeachers()
        {
            List<Teacher> teachers = new List<Teacher>()
    {
        new Teacher() { Id = 1, Name = "Rob" },
                new Teacher() { Id = 2, Name = "Mike" },
        new Teacher() { Id = 3, Name = "Mary" }
    };

            return teachers;
        }

    }
}

 