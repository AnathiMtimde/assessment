using System.Collections.Generic;
using System.Linq;
using DGSappSem2.Models.ViewModel;

namespace DGSappSem2.Models.AssessmentBusiness
{
    public class StudentViewModel
    {
        public int StID { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string StudentGrade { get; set; }
        public bool SelectGrade { get; set; }
        public int Mark { get; set; }
        public int AssessmentId { get; set; }

        public static List<ClassRoomList> getClassRoomList()
        {
            var db = new ApplicationDbContext();
            var dbList = new List<ClassRoomList>();
        
            foreach(var classRoom in db.ClassRooms)
            {
                var classRoomList = new ClassRoomList();
                classRoomList.ClassRoomID = classRoom.ClassRoomID;
                classRoomList.GradeName = classRoom.GradeName;
                classRoomList.ClassRoomSubjectLists = GetSubjectLists(classRoom.ClassRoomID);
                dbList.Add(classRoomList);
            }
          return dbList;
        }
        public static List<ClassRoomSubjectList> GetSubjectLists(int classRoomId)
        {
            var db = new ApplicationDbContext();
            var dbList = new List<ClassRoomSubjectList>();

            foreach (var subject in db.Subjects.Where(x => x.ClassRoomID == classRoomId))
            {
                var classRoomSubjectList = new ClassRoomSubjectList();
                classRoomSubjectList.SubjectID = subject.SubjectID;
                classRoomSubjectList.SubjectName = subject.SubjectName;
                classRoomSubjectList.TermLists = GetTermLists(subject.SubjectID);
                dbList.Add(classRoomSubjectList);
            }
          return dbList;
        }
        public static List<TermList> GetTermLists(int subjectId)
        {
            var db = new ApplicationDbContext();
            var dbList = new List<TermList>();

            foreach (var term in db.Terms)
            {
                var termList = new TermList();
                termList.TermID = term.TermID;
                termList.Name = term.Name;
                termList.AssessmentLists = GetAssessmentLists(subjectId, term.TermID);
                dbList.Add(termList);
            }
            return dbList;
        }
        public static List<AssessmentList> GetAssessmentLists(int subjectId, int termId)
        {
            var db = new ApplicationDbContext();
            var dbList = new List<AssessmentList>();

            foreach (var assessment in db.Assessments.Where(x=>x.SubjectID== subjectId && x.TermID==termId))
            {
                var assessmentList = new AssessmentList();
                assessmentList.AssessmentID = assessment.AssessmentID;
                assessmentList.AssessmentName = assessment.AssessmentName;
                dbList.Add(assessmentList);
            }
            return dbList;
        }
    }
}