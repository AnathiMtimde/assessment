using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DGSappSem2.Models.ViewModel;
using AssessmentBusiness;

namespace DGSappSem2.Models.AssessmentBusiness
{
    public class ReportLogic
    {
        public ReportVM GetReport(int studentId, int termId)
        {
            var db = new ApplicationDbContext();
            var reportVm = new ReportVM();
            reportVm.StID = GetStudentClassRoom(studentId).StID;
            reportVm.StudentName = GetStudentClassRoom(studentId).Student.StudentName;
            reportVm.StudentSurname = GetStudentClassRoom(studentId).Student.StudentSurname;
            reportVm.GradeName = GetStudentClassRoom(studentId).ClassRoom.GradeName;
            reportVm.TermName = db.Terms.Where(p=>p.TermID==termId).Select(m=>m.Name).FirstOrDefault();
            reportVm.subjectList = GetSubjects(GetStudentClassRoom(studentId).ClassRoom.ClassRoomID, termId, studentId);
            return reportVm;
        }

        public StudentClassRoom GetStudentClassRoom(int studentId)
        {
            var db = new ApplicationDbContext();
            var StudentClassRoomObj = db.StudentClassRooms.Where(i=>i.StID==studentId).FirstOrDefault();
            return StudentClassRoomObj;
        }
        public List<SubjectVM> GetSubjects(int classRoomId, int termId, int studentId)
        {
            var db = new ApplicationDbContext();
            var subjectList = db.Subjects.Where(i=>i.ClassRoomID==classRoomId).ToList();
            var subjectVmList = new List<SubjectVM>();
            foreach (var subject in subjectList)
            {
                var subjectVm = new SubjectVM();
                subjectVm.SubjectID = subject.SubjectID;
                subjectVm.SubjectName = subject.SubjectName;
                subjectVm.RequirementPercentage = subject.RequiredPercentage;
                subjectVm.assessments = GetAssessments(subject.SubjectID, termId, studentId);
                subjectVmList.Add(subjectVm);
            }
            return subjectVmList;
        } 
        public List<AssessmentVM> GetAssessments(int subjectId, int termId, int studentId)
        {
            var db = new ApplicationDbContext();
            var assessmentList = db.Assessments.Where(i=>i.SubjectID==subjectId && i.TermID == termId).ToList();
            var assessmentVm = new List<AssessmentVM>();
            foreach (var assessment in assessmentList)
            {
                var assessmentObj = new AssessmentVM();
                assessmentObj.AssessmentID = assessment.AssessmentID;
                assessmentObj.AssessmentName = assessment.AssessmentName;
                assessmentObj.ContributionPercent = assessment.ContributionPercent;
                assessmentObj.TotalMark = assessment.TotalMark;
                var mark = db.StudentAssessments.Where(k => k.AssessmentID == assessment.AssessmentID && k.StID == studentId).Select(g => g.Mark).FirstOrDefault();       
                    assessmentObj.ActualMark = (int)(((double)mark / (double)assessment.TotalMark)*assessment.ContributionPercent);
                assessmentVm.Add(assessmentObj);
            }
            return assessmentVm;
        }
    }
}