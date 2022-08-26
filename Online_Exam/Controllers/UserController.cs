using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Exam.Models;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace Online_Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        online_examContext db = new online_examContext();
        [HttpGet]
        [Route("ListUser")]
        public IActionResult GetUsers()
        {
            //var data = db.Users.ToList();
            var data = from user in db.Users select new { Id = user.UserId, Name = user.Name, Email = user.Email, password = user.Password, Mobile = user.Mobile, City = user.City, Dob = user.Dob.ToString("MM-dd-yyyy"), State = user.State, Qualification = user.Qualification, year = user.YearOfCompletion };
            return Ok(data);
        }// get all users
        [HttpGet]
        [Route("ListUser/{id}")]
        public IActionResult GetUser(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id cannot be null");
            }
            //var data = db.Users.Find(id);
            var data = (from user in db.Users where user.UserId == id select new { Id = user.UserId, Name = user.Name, Email = user.Email, Mobile = user.Mobile, City = user.City, Dob = user.Dob.ToString("MM-dd-yyyy"), State = user.State, Qualification = user.Qualification, year = user.YearOfCompletion }).FirstOrDefault();
            //var x = data.Dob;
            if (data == null)
            {
                return NotFound($"User {id} not present");
            }
            return Ok(data);
        }// get user by id
        [HttpPost]
        [Route("AddUser")]
        public IActionResult PostUser(User user)
        {
            //user.Dob.ToString("MM-dd-yyyy");
            if (ModelState.IsValid)
            {
                try
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.InnerException.Message);
                }
            }
            return Created("Record Successfully Added", user);
        }// add new user
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(userinfo user)
        {
            var data = db.Users.Where(e => e.Email == user.Email).FirstOrDefault();
            if (data.Password == user.Password)
            {
                return Ok("login successfull");
            }
            else
            {
                return BadRequest("email or password do not match");
            }

        }// authentication
        [HttpPut]
        [Route("EditUser")]
        public IActionResult PutUser(userinfo user)
        {
            if (ModelState.IsValid)
            {
                User odept = db.Users.Where(e => e.Email == user.Email).FirstOrDefault();
                odept.Password = user.Password;
                db.SaveChanges();
                return Ok("Record successfully edited");
            }
            return BadRequest("Unable to edit record");
        }//change password
        [HttpGet]
        [Route("Report/{id}")]
        public IActionResult GetReport(int? id)// fix this
        {
            var data = db.Reports.Include(d => d.Topic).Include(d => d.User).Where(d => d.Userid == id);
            if (data == null)
                return BadRequest("Report not found");
            else
                return Ok(data);
        }
        [HttpPost]
        [Route("AddReport")]
        public IActionResult PostReport(Report report)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Reports.Add(report);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.InnerException.Message);
                }
            }
            return Created("Report Successfully Added", report);
        }// add new report
        [HttpGet]
        [Route("GetReport")]
        public IActionResult GetAllReport()// get all reports
        {
            var data = db.Reports.ToList();
            if (data == null)
                return BadRequest("No reports found");
            else
                return Ok(data);
        }
        [HttpGet]
        [Route("GetQues")]
        public IActionResult GetQue(int topicid, int level)
        {
            var data = db.Questions.Where(q => q.Topicid == topicid && q.Level == level);
            if (data == null)
                return NotFound();
            return Ok(data);
        }// get question for user
        [HttpPost]
        [Route("AddQues")]
        public IActionResult PutQues(Question question)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Questions.Add(question);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.InnerException.Message);
                }
            }
            return Created("Question added successfully",question);
        }// adding question
        [HttpDelete]
        [Route("DeleteQues/{id}")]
        public IActionResult DeleteDept(int id)
        {
            var data = db.Questions.Find(id);
            db.Questions.Remove(data);
            db.SaveChanges();
            return Ok();
        }// delete question
        [HttpGet]
        [Route("GetAllQues")]
        public IActionResult GetAllQues()
        {
            var data = db.Questions;
            return Ok(data);
        }// get all questions
    }

}
