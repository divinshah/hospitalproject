using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Net;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using HospitalNew.Models;
using HospitalNew.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HospitalNew.Controllers
{
    public class JobApplicationController : Controller
    {
        private readonly HospitalNewContext db;

        public JobApplicationController(HospitalNewContext context)
        {
            db = context;
        }

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }
        public ActionResult List()
        {


            string query = "select * from jobapplications";

            IEnumerable<JobApplication> jobapplications = db.JobApplications.FromSql(query);

            return View(jobapplications);

        }
        public ActionResult New()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(string JobPositionTitle_New, string FirstName_New, string LastName_New, string Email_New, string Phone_New, string CoverLetter_New, string Summary_New)
        {
            string query = "insert into jobapplications (JobTitle, FirstName, LastName, Email, Phone, CoverLetter, Summary)" +
                " values (@jobtitle, @fname, @lname, @email, @phone, @coverletter, @summary)";
            SqlParameter[] myparams = new SqlParameter[6];
            myparams[0] = new SqlParameter("@jobtitle", JobPositionTitle_New);
            myparams[1] = new SqlParameter("@fname", FirstName_New);
            myparams[2] = new SqlParameter("@lname", LastName_New);
            myparams[3] = new SqlParameter("@email", Email_New);
            myparams[4] = new SqlParameter("@phone", Phone_New);
            myparams[5] = new SqlParameter("@coverletter", CoverLetter_New);
            myparams[6] = new SqlParameter("@summary", Summary_New);


            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }
        /*
        public ActionResult Edit(int? id)
        {
            if ((id == null) || (db.JobApplications.Find(id) == null))
            {
                return NotFound();
            }
            string query = "select * from jobapplications where jobapplicationid=@id";
            SqlParameter param = new SqlParameter("@id", id);
            JobApplication myresume = db.JobApplications.FromSql(query, param).FirstOrDefault();
            return View(myresume);
        }*/


        //We investigated what it means to edit a job applications
        //spongebob applies to be a doctor, but made a mistake on the application,
        //he wants to go back and edit how own applciation, but he CAN ONLY edit his own, and not patricks
        //however, our system currently only has accounts for admins. How would we know whether this is spongebob on the
        //computer or patrick?
        //because we don't have account functionality for (non-admins), we can't make edit work
        //Also, we investigated that admins shouldn't edit
        //squidward is an admin but can not change spongebob's application because those are spongebobs words, not his own.
        //so it doesn't make sense for admins to edit either
        //in conclusion, not edit.
        /*[HttpPost]
        public ActionResult Edit(int? id, string JobTitle, string FirstName, string LastName, string Email, string Phone, string CoverLetter, string Summary)
        {
            if ((id == null) || (db.JobApplications.Find(id) == null))
            {
                return NotFound();
            }
            string query = "update resumes set JobTitle=@jobtitle, FirstName=@fname, LastName=@lname, Email=@email, Phone=@phone, CoverLetter=@coverletter, Summary=@summary" +
                " where resumeid=@id";
            SqlParameter[] myparams = new SqlParameter[7];
            myparams[0] = new SqlParameter("@jobtitle", JobTitle);
            myparams[1] = new SqlParameter("@fname", FirstName);
            myparams[2] = new SqlParameter("@lname", LastName);
            myparams[3] = new SqlParameter("@email", Email);
            myparams[4] = new SqlParameter("@phone", Phone);
            myparams[5] = new SqlParameter("@coverletter", CoverLetter);
            myparams[6] = new SqlParameter("@summary", Summary);
            myparams[7] = new SqlParameter("@id", id);

            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("Show/" + id);
        }*/

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if ((id == null) || (db.JobApplications.Find(id) == null))
            {
                return NotFound();

            }

            string query = "delete from jobposition where jobapplicationid=@id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);


            query = "delete from jobapplications where jobapplicationid=@id";
            SqlParameter param2 = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param2);
            return View("List");
        }
        public ActionResult Show(int? id)
        {
            //this is for squidward (admin) to review spongebob's job application to be a doctor
            if ((id == null) || (db.JobApplications.Find(id) == null))
            {
                return NotFound();

            }
            string query = "select * from jobapplications where jobapplicationid=@id";
            SqlParameter param = new SqlParameter("@id", id);


            //[db.JobApplications.Where(ja=>ja.JobApplicationID==id)] => just to get the jobapplication itself (spongebobs application)
            //[.Include(ja=>ja.JobPositionID)] => this is the jobposition (spongebob applying to be a doctor)
            //select * from jobapplications 
            //left join jobs on jobs.jobid = jobapplications.jobid
            //where jobapplicationod=id
            var jobapp = db.JobApplications.Where(ja => ja.JobApplicationID == id).Include(ja => ja.JobPositionID);

            return View(jobapp);

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