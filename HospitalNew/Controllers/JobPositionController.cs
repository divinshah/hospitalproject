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
    public class JobPositionController : Controller
    {
        //makes a HospitalCMSContext
        private readonly HospitalNewContext db;

        private readonly IHostingEnvironment _env;

        public JobPositionController(HospitalNewContext context, IHostingEnvironment env)
        {
            db = context;
            _env = env;
        }


        // GET: 
        public ActionResult Index()
        {

            return View(db.JobPositions.ToList());
        }

        public ActionResult Show(int id)
        {
            //wrapper
            return RedirectToAction("Details/" + id);
        }

        public ActionResult List()
        {
            //LIST WILL SHOW ALL JOB POSITIONS
            //WHAT INFORMATION DO I NEED
            List<JobPosition> jobpositions = db.JobPositions.Include(h => h.Hospital).Include(d => d.DepartmentID).Include(ja => ja.jobapplications).ToList();

            //GOTO Views/jobposition/List.cshtml
            return View(jobpositions);
        }

        public ActionResult New()
        {
            JobPositionEdit positioneditview = new JobPositionEdit();


            //object positioneditview = null;
            positioneditview.Hospitals = db.Hospitals.ToList();

            //GOTO Views/Position/New.cshtml
            return View(positioneditview);
        }

        [HttpPost]
        public ActionResult Create(string HospitalTitle_New, string JobTitle_New, string Department_New, string JobType_New, string JobDesc_New, string JobReq_New, int JobApplication_New)
        {


            //Query   
            string query = "insert into jobpositions (HospitalTitle, JobTitle,Department, JobType, JobDesc, JobReq,  JobApplicationID) values (@location, @title, @department,@type, @desc, @req, @resume)";


            SqlParameter[] myparams = new SqlParameter[6];
            //@title paramter
            myparams[0] = new SqlParameter("@location", HospitalTitle_New);
            //@type paramter
            myparams[1] = new SqlParameter("@title", JobTitle_New);
            //@category (id) FOREIGN KEY param
            myparams[2] = new SqlParameter("@department", Department_New);
            //@type paramter
            myparams[3] = new SqlParameter("@type", JobType_New);
            //@desc parameter
            myparams[4] = new SqlParameter("@desc", JobDesc_New);
            //@req parameter
            myparams[5] = new SqlParameter("@req", JobReq_New);
            //@resume (id) FOREIGN KEY param
            myparams[6] = new SqlParameter("@resume", JobApplication_New);
            //Run the parameterized query (DML - Data Manipulation Language)
            //Insert into job ( .. ) values ( .. ) 
            db.Database.ExecuteSqlCommand(query, myparams);

            //GOTO: 
            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {


            JobPositionEdit positioneditview = new JobPositionEdit();


            positioneditview.Hospitals = db.Hospitals.ToList(); //Finds all hospitals


            positioneditview.JobPosition = db.JobPositions.Include(h => h.Hospital).SingleOrDefault(j => j.JobID == id); //finds all job

            //GOTO: Views/Job/Edit.cshtml
            return View(positioneditview);
        }

        [HttpPost]
        public ActionResult Edit(int id, string HospitalTitle, string JobTitle, string Department, string JobType, string JobDesc, string JobReq, int PositionResume)
        {

            if ((id == null) || (db.JobPositions.Find(id) == null))
            {
                return NotFound();

            }
            //Raw Update MSSQL query
            string query = "update jobpositions set HospitalTitle=@location, JobTitle=@title, Department = @department, JobType=@type,JobDesc=@desc, JobReq=@req,ResumeID=@resume where JobID=@id";


            SqlParameter[] myparams = new SqlParameter[7];
            //Parameter for @title "jobtitle"
            myparams[0] = new SqlParameter("@location", HospitalTitle);
            //Parameter for @type "jobtype"
            myparams[1] = new SqlParameter("@title", JobTitle);
            //Parameter for (category) id FOREIGN KEY
            myparams[2] = new SqlParameter("@department", Department);
            //Parameter for (category) id FOREIGN KEY
            myparams[3] = new SqlParameter("@type", JobType);
            //Parameter for @desc "JobDesc"
            myparams[4] = new SqlParameter("@desc", JobDesc);
            //Parameter for @req "JobReq"
            myparams[5] = new SqlParameter("@req", JobReq);
            //Parameter for (resume) id FOREIGN KEY
            myparams[6] = new SqlParameter("@resume", PositionResume);
            //Pararameter for (Position) id PRIMARY KEY
            myparams[7] = new SqlParameter("@id", id);

            //Execute the custom SQL command with parameters
            db.Database.ExecuteSqlCommand(query, myparams);

            //GOTO: View/Blog/Show.cshtml with paramter Blogid passed
            return RedirectToAction("Show/" + id);
        }
        public ActionResult Show(int? id)
        {

            if ((id == null) || (db.JobPositions.Find(id) == null))
            {
                return NotFound();

            }
            //Raw MSSQL query
            string query = "select * from jobpositions where jobid=@id";


            SqlParameter myparam = new SqlParameter("@id", id);


            JobPosition myjob = db.JobPositions.Include(h => h.Hospital).Include(j => j.jobapplications).SingleOrDefault(b => b.JobID == id);

            return View(myjob);

        }

        public ActionResult Delete(int? id)
        {

            if ((id == null) || (db.JobPositions.Find(id) == null))
            {
                return NotFound();

            }

            string query = "delete from hospitals where JobID=@id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);

            query = "delete from jobapplications where JobID=@id";
            param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);

            query = "delete from departments where JobID=@id";
            param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);

            query = "delete from jobpositions where jobid=@id";
            param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);
            return RedirectToAction("List");


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
