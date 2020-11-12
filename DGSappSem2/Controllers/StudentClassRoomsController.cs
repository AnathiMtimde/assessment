using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DGSappSem2.Models.AssessmentBusiness;
using DGSappSem2.Models;
using AssessmentBusiness;

namespace DGSappSem2.Controllers
{
    public class StudentClassRoomsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentClassRooms
        public ActionResult Index()
        {
            var studentClassRooms = db.StudentClassRooms.Include(s => s.ClassRoom).Include(s => s.Student);
            return View(studentClassRooms.ToList());
        }

        // GET: StudentClassRooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentClassRoom studentClassRoom = db.StudentClassRooms.Find(id);
            if (studentClassRoom == null)
            {
                return HttpNotFound();
            }
            return View(studentClassRoom);
        }

        // GET: StudentClassRooms/Create
        public ActionResult Create()
        {
            ViewBag.ClassRoomID = new SelectList(db.ClassRooms, "ClassRoomID", "GradeName");
           // ViewBag.StID = new SelectList(db.students, "StID", "StudentName");
            
            return View(GetStudents());
        }

       
        // POST: StudentClassRooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(List<StudentViewModel> studentVms, int ClassRoomID)
        {
            ViewBag.ClassRoomID = new SelectList(db.ClassRooms, "ClassRoomID", "GradeName");
            var selectedCheckbox = false;

            foreach(var item in studentVms)
            {
                if (item.SelectGrade)
                {
                    selectedCheckbox = true;
                }
            }

            if (selectedCheckbox)
            {
                foreach (var item in studentVms)
                {
                    if (item.SelectGrade)
                    {
                        var studentClassroom = new StudentClassRoom();
                        studentClassroom.ClassRoomID = ClassRoomID;
                        studentClassroom.StID = item.StID;
                        studentClassroom.DateCreated = DateTime.Now;
                        db.StudentClassRooms.Add(studentClassroom);
                        db.SaveChanges();
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Please select atleast one student");
                return View(GetStudents());
            }

            return RedirectToAction("Index");
        }

        // GET: StudentClassRooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentClassRoom studentClassRoom = db.StudentClassRooms.Find(id);
            if (studentClassRoom == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassRoomID = new SelectList(db.ClassRooms, "ClassRoomID", "GradeName", studentClassRoom.ClassRoomID);
            ViewBag.StID = new SelectList(db.students, "StID", "StudentName", studentClassRoom.StID);
            return View(studentClassRoom);
        }

        // POST: StudentClassRooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentClassRoomID,DateCreated,ClassRoomID,StID")] StudentClassRoom studentClassRoom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentClassRoom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassRoomID = new SelectList(db.ClassRooms, "ClassRoomID", "GradeName", studentClassRoom.ClassRoomID);
            ViewBag.StID = new SelectList(db.students, "StID", "StudentName", studentClassRoom.StID);
            return View(studentClassRoom);
        }

        // GET: StudentClassRooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentClassRoom studentClassRoom = db.StudentClassRooms.Find(id);
            if (studentClassRoom == null)
            {
                return HttpNotFound();
            }
            return View(studentClassRoom);
        }

        // POST: StudentClassRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentClassRoom studentClassRoom = db.StudentClassRooms.Find(id);
            db.StudentClassRooms.Remove(studentClassRoom);
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

        public List<StudentViewModel> GetStudents()
        {
            var stdList = new List<StudentViewModel>();

            foreach (var item in db.students.ToList())
            {
                var student = new StudentViewModel();
                student.StID = item.StID;
                student.StudentName = item.StudentName;
                student.StudentSurname = item.StudentSurname;
                student.StudentGrade = item.StudentGrade;
                stdList.Add(student);
            }
            return stdList;
        }
    }
}
