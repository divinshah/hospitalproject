using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Net;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using HospitalNew.Models;
using HospitalNew.Models.ViewModels;
using HospitalNew.Data;
using Microsoft.AspNetCore.Hosting;

namespace HospitalNew.Controllers
{
    public class VolunteerController : Controller
    {
        private readonly HospitalNewContext db;

        public VolunteerController(HospitalNewContext context)
        {
            db = context;
        }

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }


        public ActionResult List()
        {


            string query = "select * from volunteers";

            List<Volunteer> volunteers = db.Volunteers.Include(v => v.Hospital).ToList();

            return View(volunteers);

        }


        public ActionResult New()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(string HospitalTitle_New, string FirstName_New, string LastName_New, string MiddleName_New, string Street_New, string City_New, string Province_New, string Zip_New, string Phone_New, string Email_New, string Age_New, string Gender_New, string Education_New, string Experience_New, string Availability_New, string Name_New, string Phone_em_New, string Relationship_New, string HealthCondition_New)
        {
            string query = "insert into volunteers ( HospitalTitle, FirstName, LastName, MiddleName,Street, City, Province, Zip, Phone,Email, Age, Gender,Education, Experience, Availability, Name, Phone_em, Relationship, HealthCondition)" +
                " values ( @location,@fname, @lname,@mname,@street,@city, @province,@zip, @phone, @email,@age, @gender, @education, @experience, @availability, @name, @phone_em, @relationship, @healthcondition)";
            SqlParameter[] myparams = new SqlParameter[18];
            myparams[0] = new SqlParameter("@locayion", HospitalTitle_New);
            myparams[1] = new SqlParameter("@fname", FirstName_New);
            myparams[2] = new SqlParameter("@lname", LastName_New);
            myparams[3] = new SqlParameter("@mname", MiddleName_New);
            myparams[4] = new SqlParameter("@street", Street_New);
            myparams[5] = new SqlParameter("@city", City_New);
            myparams[6] = new SqlParameter("@province", Province_New);
            myparams[7] = new SqlParameter("@zip", Zip_New);
            myparams[8] = new SqlParameter("@phone", Phone_New);
            myparams[9] = new SqlParameter("@email", Email_New);
            myparams[10] = new SqlParameter("@age", Age_New);
            myparams[11] = new SqlParameter("@gender", Gender_New);
            myparams[12] = new SqlParameter("@education", Education_New);
            myparams[13] = new SqlParameter("@experience", Experience_New);
            myparams[14] = new SqlParameter("@availability", Availability_New);
            myparams[15] = new SqlParameter("@name", Name_New);
            myparams[16] = new SqlParameter("@phone_em", Phone_em_New);
            myparams[17] = new SqlParameter("@relationship", Relationship_New);
            myparams[18] = new SqlParameter("@healthcondition", HealthCondition_New);


            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }



        public ActionResult Edit(int id)
        {


            VolunteerEdit voleditview = new VolunteerEdit();

            voleditview.Volunteer = db.Volunteers.Include(h => h.Hospital).SingleOrDefault(vl => vl.VolunteerID == id); //finds all volunteer

            //GOTO: Views/Job/Edit.cshtml
            return View(voleditview);
        }


        [HttpPost]
        public ActionResult Edit(int? id, string HospitalTitle, string FirstName, string LastName, string MiddleName, string Street, string City, string Province, string Zip, string Phone, string Email, string Age, string Gender, string Education, string Experience, string Availability, string Name, string Phone_em, string Relationship, string HealthCondition)
        {
            if ((id == null) || (db.Volunteers.Find(id) == null))
            {
                return NotFound();
            }
            string query = "update volunteers set HospitalTitle=@location, FirstName=@fname, LastName=@lname, MiddleName=@mname, Street=@street, City=@city, Province=@province, Zip=@zip, Phone=@phone, Email=@email, Aage=@age, Gender=@gender, Education=@education, Experience=@experience, Availability=@availability, Name=@name, Phone_em=@phone_em, Relationship=@relationship, HealthCondition=@healthcondition" +
                " where volunteerid=@id";
            SqlParameter[] myparams = new SqlParameter[19];

            myparams[0] = new SqlParameter("@fname", FirstName);
            myparams[1] = new SqlParameter("@fname", FirstName);
            myparams[2] = new SqlParameter("@lname", LastName);
            myparams[3] = new SqlParameter("@mname", MiddleName);
            myparams[4] = new SqlParameter("@street", Street);
            myparams[5] = new SqlParameter("@city", City);
            myparams[6] = new SqlParameter("@province", Province);
            myparams[7] = new SqlParameter("@zip", Zip);
            myparams[8] = new SqlParameter("@phone", Phone);
            myparams[9] = new SqlParameter("@email", Email);
            myparams[10] = new SqlParameter("@age", Age);
            myparams[11] = new SqlParameter("@gender", Gender);
            myparams[12] = new SqlParameter("@education", Education);
            myparams[13] = new SqlParameter("@experience", Experience);
            myparams[14] = new SqlParameter("@availability", Availability);
            myparams[15] = new SqlParameter("@name", Name);
            myparams[16] = new SqlParameter("@phone_em", Phone_em);
            myparams[17] = new SqlParameter("@relationship", Relationship);
            myparams[18] = new SqlParameter("@healthcondition", HealthCondition);
            myparams[19] = new SqlParameter("@id", id);

            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("Show/" + id);
        }
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if ((id == null) || (db.Volunteers.Find(id) == null))
            {
                return NotFound();

            }
            string query = "delete from volunteers where volunteerid=@id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);
            return View("List");
        }


        public ActionResult Show(int? id)
        {
            if ((id == null) || (db.Volunteers.Find(id) == null))
            {
                return NotFound();

            }
            string query = "select * from volunteers where volunteerid=@id";
            SqlParameter param = new SqlParameter("@id", id);

            Volunteer volunshow = db.Volunteers.Include(v => v.Hospital).SingleOrDefault(vl => vl.VolunteerID == id);

            return View(volunshow);

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}