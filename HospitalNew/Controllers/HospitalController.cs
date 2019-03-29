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
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace HospitalNew.Controllers
{
    public class HospitalController : Controller
    {
        //makes a HospitalCMSContext
        private readonly HospitalNewContext db;

        private readonly IHostingEnvironment _env;

        public HospitalController(HospitalNewContext context, IHostingEnvironment env)
        {
            db = context;
            _env = env;
        }



        // GET: Hospitals
        public ActionResult Index()
        {

            return View(db.Hospitals.ToList());
        }

        public ActionResult List()
        {


            string query = "select * from hospitals";

            IEnumerable<Hospital> hospitals = db.Hospitals.FromSql(query);

            return View(hospitals);

        }


        public ActionResult Show(int id)
        {
            //wrapper
            return RedirectToAction("Details/" + id);
        }


        // GET: Hospitals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hospitals/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("HospitalID,HospitalTitle,Address,Email,Phone,Description")] Hospital hospital)
        {

            if (ModelState.IsValid)
            {
                db.Hospitals.Add(hospital);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hospital);
        }



        // POST: Hospitals/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("HospitalID,HospitalTitle,Address,Phone, Description")] Hospital hospital, IFormFile authorimg)
        {
            //default to false (no pic)
            hospital.HasPic = 0;
            var webRoot = _env.WebRootPath;
            if (authorimg != null)
            {
                if (authorimg.Length > 0)
                {

                    var valtypes = new[] { "jpeg", "jpg", "png", "gif" };
                    var extension = Path.GetExtension(authorimg.FileName).Substring(1);

                    if (valtypes.Contains(extension))
                    {


                        string fn = hospital.HospitalID + "." + extension;

                        //get a direct file path to imgs/hospitals/
                        string path = Path.Combine(webRoot, "images/hospitals");
                        path = Path.Combine(path, fn);

                        //save the file
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            authorimg.CopyTo(stream);
                        }
                        //let the model know that there is a picture with an extension
                        hospital.HasPic = 1;
                        hospital.ImgType = extension;

                    }
                }
            }
            if (ModelState.IsValid)
            {
                db.Entry(hospital).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hospital);
        }


        // GET: Hospitals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(400);
            }
            Hospital hospital = db.Hospitals.Find(id);
            if (hospital == null)
            {
                return NotFound();
            }
            return View(hospital);
        }

        // POST: Hospitals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hospital hospital = db.Hospitals.Find(id);
            db.Hospitals.Remove(hospital);
            db.SaveChanges();
            return RedirectToAction("Index");
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

