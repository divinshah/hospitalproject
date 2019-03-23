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
        private readonly HospitalCMSContext db;

        private readonly IHostingEnvironment _env;

        public JobPositionController(HospitalCMSContext context, IHostingEnvironment env)
        {
            db = context;
            _env = env;
        }
        public JobPositionController(HospitalCMSContext context)
        {
            db = context;
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
            
            List<JobPosition> jobpositions = db.JobPositions.Include(b => b.Hospital).ToList();

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
        public ActionResult Create(string JobLocation_New, string JobTitle_New, string PositCategory_New, string JobType_New, string JobDesc_New, string JobReq_New, int PositionResume_New)
        {


            //Query   
            string query = "insert into positions (JobLocation, JobTitle,CategoryID, JobType, JobDesc, JobReq,  ResumeID) values (@location, @title, @category,@type, @desc, @req, @resume)";


            SqlParameter[] myparams = new SqlParameter[6];
            //@title paramter
            myparams[0] = new SqlParameter("@location", JobLocation_New);
            //@type paramter
            myparams[1] = new SqlParameter("@title", JobTitle_New);
            //@category (id) FOREIGN KEY param
            myparams[2] = new SqlParameter("@category", PositCategory_New);
            //@type paramter
            myparams[3] = new SqlParameter("@type", JobType_New);
            //@desc parameter
            myparams[4] = new SqlParameter("@desc", JobDesc_New);
            //@req parameter
            myparams[5] = new SqlParameter("@req", JobReq_New);
            //@resume (id) FOREIGN KEY param
            myparams[6] = new SqlParameter("@resume", PositionResume_New);
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


            positioneditview.JobPosition = db.JobPositions.Include(b => b.Hospital).SingleOrDefault(b => b.JobID == id); //finds all job

            //GOTO: Views/Blog/Edit.cshtml
            return View(positioneditview);
        }

        [HttpPost]
        public ActionResult Edit(int id, string JobLocation, string JobTitle, int PositCategory, string JobDesc, string JobReq, int PositionResume)
        {

            if ((id == null) || (db.JobPositions.Find(id) == null))
            {
                return NotFound();

            }
            //Raw Update MSSQL query
            string query = "update positions set JobLocation=@location, JobTitle=@title, PositCategoty = @category, JobType=@type,JobDesc=@desc, JobReq=@req,ResumeID=@resume where JobID=@id";


            SqlParameter[] myparams = new SqlParameter[7];
            //Parameter for @title "jobtitle"
            myparams[0] = new SqlParameter("@location", JobLocation);
            //Parameter for @type "jobtype"
            myparams[1] = new SqlParameter("@title", JobTitle);
            //Parameter for (category) id FOREIGN KEY
            myparams[2] = new SqlParameter("@category", PositCategory);
            //Parameter for (category) id FOREIGN KEY
            myparams[3] = new SqlParameter("@type", PositCategory);
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
            string query = "select * from positions where jobid=@id";


            SqlParameter myparam = new SqlParameter("@id", id);


            JobPosition myjob = db.JobPositions.Include(b => b.Hospital).Include(b => b.ResumeID).SingleOrDefault(b => b.JobID == id);

            return View(myjob);

        }
        public ActionResult Delete(int? id)
        {

            if ((id == null) || (db.JobPositions.Find(id) == null))
            {
                return NotFound();

            }

            string query = "delete from PositionsxResumes where JobID in (select JobID from positions where JobID=@id)";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);

            query = "delete from positions where JobID=@id";
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
    
