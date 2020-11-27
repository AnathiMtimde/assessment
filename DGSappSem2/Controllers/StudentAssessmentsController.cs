using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DGSappSem2.Models;
using DGSappSem2.Models.AssessmentBusiness;
using DGSappSem2.Models.ViewModel;

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
        public ActionResult DetailedReport(int studentId, int termId)
        {
            var report =new ReportLogic();
            var mtlist = report.GetReport(studentId, termId);
            return View(mtlist);
        }
        public ActionResult StudentList(int classRoomId, string gradeName)
        {
            ViewBag.gradeName = gradeName;
            ViewBag.classRoomId = classRoomId;
            var students = db.StudentClassRooms.Where(c => c.ClassRoomID == classRoomId).ToList();
            var studentList = new List<studentVM>();
            var termList = db.Terms.ToList();
            foreach (var student in students)
            {
                var studentProfile = db.students.Where(h => h.StID == student.StID).FirstOrDefault();
                var student1 = new studentVM();
                student1.StID = student.StID;
                student1.StudentName = studentProfile.StudentName;
                student1.StudentSurname = studentProfile.StudentSurname;
                student1.termLists = termList;
                studentList.Add(student1);
            }
            return View(studentList);
        }
        public ActionResult SummaryReport(int classroomId,int studentId,int termId)
        {
            var report = new ReportLogic();
            var mtlist = report.getReportVM(classroomId,studentId,termId);
            return View(mtlist);
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
        public ActionResult Create(int classroomId, int assessmentId)
        {
            ViewBag.ClassroomId = classroomId;
            ViewBag.AssessmentId = assessmentId;
            ViewBag.AssessmentName = db.Assessments.Where(c => c.AssessmentID == assessmentId).Select(c=>c.AssessmentName).FirstOrDefault();
            ViewBag.GradeName = db.ClassRooms.Where(d => d.ClassRoomID == classroomId).Select(d => d.GradeName).FirstOrDefault();
            ViewBag.Subject = db.Assessments.Where(d => d.AssessmentID == assessmentId).Select(d => d.Subject.SubjectName).FirstOrDefault();
            ViewBag.Term = db.Assessments.Where(d => d.AssessmentID == assessmentId).Select(d => d.Term.Name).FirstOrDefault();
            return View(GetStudents(classroomId,assessmentId));
        }
        public ActionResult MarksList(int classroomId, int assessmentId)
        {
            ViewBag.ClassroomId = classroomId;
            ViewBag.AssessmentId = assessmentId;
            ViewBag.AssessmentName = db.Assessments.Where(c => c.AssessmentID == assessmentId).Select(c=>c.AssessmentName).FirstOrDefault();
            ViewBag.gradeName = db.ClassRooms.Where(d => d.ClassRoomID == classroomId).Select(d => d.GradeName).FirstOrDefault();
            ViewBag.subjectName = db.Assessments.Where(d => d.AssessmentID == assessmentId).Select(d => d.Subject.SubjectName).FirstOrDefault();  
            ViewBag.subjectId = db.Assessments.Where(d => d.AssessmentID == assessmentId).Select(d => d.Subject.SubjectID).FirstOrDefault();
            ViewBag.termName = db.Assessments.Where(d => d.AssessmentID == assessmentId).Select(d => d.Term.Name).FirstOrDefault();
            ViewBag.termId = db.Assessments.Where(d => d.AssessmentID == assessmentId).Select(d => d.Term.TermID).FirstOrDefault();
            return View(GetStudents(classroomId,assessmentId));
        }

        // POST: StudentAssessments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(List<StudentViewModel> studentVms, int classroomId, int assessmentId)
        {
            var nullMark = false;
            var totalMark = db.Assessments.Where(h => h.AssessmentID == assessmentId).Select(h => h.TotalMark).FirstOrDefault();
            foreach (var item in studentVms)
            {
                if (item.Mark<0 || totalMark <item.Mark)
                {
                    nullMark = true;
                }
            }
            if (!nullMark)
            {
                foreach (var item in studentVms)
                {
                    var studentAssessment = new StudentAssessment();
                    var getMark = db.StudentAssessments.Where(c => c.StID == item.StID && c.AssessmentID == item.AssessmentId).FirstOrDefault();
                    if (getMark != null)
                    {
                        getMark.Mark = item.Mark;
                        db.Entry(getMark).State = EntityState.Modified;
                    }
                    else
                    {
                        studentAssessment.StID = item.StID;
                        studentAssessment.AssessmentID = item.AssessmentId;
                        studentAssessment.Mark = item.Mark;
                        db.StudentAssessments.Add(studentAssessment);
                    }
                    db.SaveChanges();
                }
            }
            else
            {
                ViewBag.ClassroomId = classroomId;
                ViewBag.AssessmentId = assessmentId;
                ViewBag.AssessmentName = db.Assessments.Where(c => c.AssessmentID == assessmentId).Select(c => c.AssessmentName).FirstOrDefault();
                ViewBag.GradeName = db.ClassRooms.Where(d => d.ClassRoomID == classroomId).Select(d => d.GradeName).FirstOrDefault();
                ViewBag.Subject = db.Assessments.Where(d => d.AssessmentID == assessmentId).Select(d => d.Subject.SubjectName).FirstOrDefault();
                ViewBag.Term = db.Assessments.Where(d => d.AssessmentID == assessmentId).Select(d => d.Term.Name).FirstOrDefault();

                ModelState.AddModelError("", "A mark cannot be less than zero or greater than the total mark : " +totalMark);
                return View(GetStudents(classroomId,assessmentId));
            }
            return RedirectToAction("Index");
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
        public List<StudentViewModel> GetStudents(int classroomId, int assessmentId)
        {
            var stdList = new List<StudentViewModel>();
            var classroomStudents = db.StudentClassRooms.Where(c => c.ClassRoomID == classroomId).Select(c => c.StID).ToList();
            foreach (var studentId in classroomStudents)
            {
                var item = db.students.Where(g => g.StID == studentId).FirstOrDefault();
                var mark = db.StudentAssessments.Where(g => g.StID == studentId && g.AssessmentID == assessmentId).Select(j=>j.Mark).FirstOrDefault();
                var student = new StudentViewModel();
                student.StID = item.StID;
                student.AssessmentId = assessmentId;
                student.StudentName = item.StudentName;
                student.StudentSurname = item.StudentSurname;
                student.StudentGrade = item.StudentGrade;
                student.Mark = mark; 
                stdList.Add(student);
            }
            return stdList;
        }
    }
}
