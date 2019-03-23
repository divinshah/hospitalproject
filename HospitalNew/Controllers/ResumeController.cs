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
    public class ResumeController : Controller
    {
        private readonly HospitalCMSContext db;
        
        public ResumeController(HospitalCMSContext context)
        {
            db = context;
        }

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }
        public ActionResult List()
        {
           

            string query = "select * from Tags";

            IEnumerable<Resume> resumes = db.Resumes.FromSql(query);

            return View(resumes);

        }
        public ActionResult New()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(string JobTitle_New, string FirstName_New, string LastName_New,string Email_New,string Phone_New, string CoverLetter_New, string Summary_New)
        {
            string query = "insert into resumes (JobTitle, FirstName, LastName, Email, Phone, CoverLetter, Summary)" +
                " values (@jobtitle, @fname, @lname, @email, @phone, @coverletter, @summary)";
            SqlParameter[] myparams = new SqlParameter[6];
            myparams[0] = new SqlParameter("@jobtitle", JobTitle_New);
            myparams[1] = new SqlParameter("@fname", FirstName_New);
            myparams[2] = new SqlParameter("@lname", LastName_New);
            myparams[3] = new SqlParameter("@email", Email_New);
            myparams[4] = new SqlParameter("@phone", Phone_New);
            myparams[5] = new SqlParameter("@coverletter", CoverLetter_New);
            myparams[6] = new SqlParameter("@summary", Summary_New);


            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }
        public ActionResult Edit(int? id)
        {
            if ((id == null) || (db.Resumes.Find(id) == null))
            {
                return NotFound();
            }
            string query = "select * from resumes where resumeid=@id";
            SqlParameter param = new SqlParameter("@id", id);
            Resume myresume = db.Resumes.FromSql(query, param).FirstOrDefault();
            return View(myresume);
        }
        [HttpPost]
        public ActionResult Edit(int? id, string JobTitle, string FirstName, string LastName, string Email, string Phone, string CoverLetter, string Summary)
        {
            if ((id == null) || (db.Resumes.Find(id) == null))
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
        }
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if ((id == null) || (db.Resumes.Find(id) == null))
            {
                return NotFound();

            }
            string query = "delete from resumes where resumeid=@id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);
            return View("List");
        }
        public ActionResult Show(int? id)
        {
            if ((id == null) || (db.Resumes.Find(id) == null))
            {
                return NotFound();

            }
            string query = "select * from resumes where resumeid=@id";
            SqlParameter param = new SqlParameter("@id", id);

            Resume resumeshow = db.Resumes.Include(t => t.jobpositionsxresumes).ThenInclude(pxt => pxt.JobPosition).SingleOrDefault(t => t.ResumeID == id);

            return View(resumeshow);

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