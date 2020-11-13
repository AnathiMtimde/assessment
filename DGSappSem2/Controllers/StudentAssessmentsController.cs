using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DGSappSem2.Models;

namespace DGSappSem2.Controllers
{
    public class StudentAssessmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentAssessments
        public ActionResult Index()
        {
            var studentAssessments = db.StudentAssessments.Include(s => s.Assessment).Include(s => s.Student);
            return View(studentAssessments.ToList());
        }

        // GET: StudentAssessments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAssessment studentAssessment = db.StudentAssessments.Find(id);
            if (studentAssessment == null)
            {
                return HttpNotFound();
            }
            return View(studentAssessment);
        }

        // GET: StudentAssessments/Create
        public ActionResult Create()
        {
            ViewBag.AssessmentID = new SelectList(db.Assessments, "AssessmentID", "AssessmentName");
            ViewBag.StID = new SelectList(db.students, "StID", "StudentName");
            return View();
        }

        // POST: StudentAssessments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentAssesmentID,StID,AssessmentID,Mark")] StudentAssessment studentAssessment)
        {
            if (ModelState.IsValid)
            {
                db.StudentAssessments.Add(studentAssessment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssessmentID = new SelectList(db.Assessments, "AssessmentID", "AssessmentName", studentAssessment.AssessmentID);
            ViewBag.StID = new SelectList(db.students, "StID", "StudentName", studentAssessment.StID);
            return View(studentAssessment);
        }

        // GET: StudentAssessments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAssessment studentAssessment = db.StudentAssessments.Find(id);
            if (studentAssessment == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssessmentID = new SelectList(db.Assessments, "AssessmentID", "AssessmentName", studentAssessment.AssessmentID);
            ViewBag.StID = new SelectList(db.students, "StID", "StudentName", studentAssessment.StID);
            return View(studentAssessment);
        }

        // POST: StudentAssessments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentAssesmentID,StID,AssessmentID,Mark")] StudentAssessment studentAssessment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentAssessment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssessmentID = new SelectList(db.Assessments, "AssessmentID", "AssessmentName", studentAssessment.AssessmentID);
            ViewBag.StID = new SelectList(db.students, "StID", "StudentName", studentAssessment.StID);
            return View(studentAssessment);
        }

        // GET: StudentAssessments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAssessment studentAssessment = db.StudentAssessments.Find(id);
            if (studentAssessment == null)
            {
                return HttpNotFound();
            }
            return View(studentAssessment);
        }

        // POST: StudentAssessments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentAssessment studentAssessment = db.StudentAssessments.Find(id);
            db.StudentAssessments.Remove(studentAssessment);
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
