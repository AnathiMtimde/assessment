using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssessmentBusiness;
using DGSappSem2.Models;

namespace DGSappSem2.Controllers
{
    public class AssessmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Assessments
        public ActionResult Index()
        {
            var assessments = db.Assessments.Include(a => a.Subject).Include(a => a.Term);
            return View(assessments.ToList());
        } 
        public ActionResult AssessmentList(int subjectId, int termId, string gradeName, string termName, string subjectName)
        {
            ViewBag.gradeName = gradeName;
            ViewBag.termName = termName;
            ViewBag.subjectName = subjectName;
            ViewBag.subjectId = subjectId;
            ViewBag.termId = termId;
            var assessments = db.Assessments.Include(a => a.Subject).Include(a => a.Term).Where(h=>h.SubjectID == subjectId && h.TermID == termId);
            return View(assessments.ToList());
        }

        // GET: Assessments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assessment assessment = db.Assessments.Find(id);
            if (assessment == null)
            {
                return HttpNotFound();
            }
            return View(assessment);
        }

        // GET: Assessments/Create
        public ActionResult Create(int subjectId, int termId, string gradeName, string termName, string subjectName)
        {
            ViewBag.gradeName = gradeName;
            ViewBag.termName = termName;
            ViewBag.subjectName = subjectName;
            ViewBag.SubjectID = subjectId;
            ViewBag.TermID = termId;
            return View();
        }

        // POST: Assessments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create( Assessment assessment)
        {
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName");
            ViewBag.TermID = new SelectList(db.Terms, "TermID", "Name");
            if (ModelState.IsValid)
            {
                var existingAssessments = db.Assessments.Where(x => x.SubjectID == assessment.SubjectID && x.TermID == assessment.TermID).FirstOrDefault();
                if (existingAssessments != null)
                {
                    var existingPercentage = db.Assessments.Where(x => x.SubjectID == assessment.SubjectID && x.TermID == assessment.TermID).Select(s => s.ContributionPercent).Sum();
                    if (100 >= (existingPercentage + assessment.ContributionPercent))
                    {
                        db.Assessments.Add(assessment);
                        db.SaveChanges();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Your total contribution percentage must be equal to 100% ");
                        return View();
                    }
                }
                else
                {
                    db.Assessments.Add(assessment);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", assessment.SubjectID);
            ViewBag.TermID = new SelectList(db.Terms, "TermID", "Name", assessment.TermID);
            return View(assessment);
        }

        // GET: Assessments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assessment assessment = db.Assessments.Find(id);
            if (assessment == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", assessment.SubjectID);
            ViewBag.TermID = new SelectList(db.Terms, "TermID", "Name", assessment.TermID);
            return View(assessment);
        }

        // POST: Assessments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssessmentID,AssessmentName,ContributionPercent,TermID,SubjectID")] Assessment assessment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assessment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", assessment.SubjectID);
            ViewBag.TermID = new SelectList(db.Terms, "TermID", "Name", assessment.TermID);
            return View(assessment);
        }

        // GET: Assessments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assessment assessment = db.Assessments.Find(id);
            if (assessment == null)
            {
                return HttpNotFound();
            }
            return View(assessment);
        }

        // POST: Assessments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Assessment assessment = db.Assessments.Find(id);
            db.Assessments.Remove(assessment);
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
