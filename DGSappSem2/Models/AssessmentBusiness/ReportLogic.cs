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

        public int getSubjectTotal(int subjectId, int termId, int studentId)
        {
            var assessmentList = GetAssessments(subjectId, termId, studentId);
            var subjectTotal = 0;

            foreach(var assessment in assessmentList )
            {
                subjectTotal += assessment.ActualMark;
            }
            return subjectTotal;
        }

        public int getSubjectAverage(int subjectId, int termId, int classRoomId)
        {
            var db = new ApplicationDbContext();
            var subjectAverage = 0;
            var getStudentList = db.StudentClassRooms.Where(s => s.ClassRoomID == classRoomId).Select(s => s.StID).ToList();
            foreach(var studentId in getStudentList)
            {
                subjectAverage += getSubjectTotal(subjectId, termId, studentId);
            }
            subjectAverage =(int) ((double)subjectAverage / (double)getStudentList.Count);
            return subjectAverage;
        }
        public ReportVM getReportVM(int classRoomId,int studentId, int termId)
        {
            var db = new ApplicationDbContext();
            var report = new ReportVM();
            var getStudentDetails = db.students.Where(f => f.StID == studentId).FirstOrDefault();
            report.StudentName = getStudentDetails.StudentName;
            report.StudentSurname = getStudentDetails.StudentSurname;
            report.GradeName = db.ClassRooms.Where(d => d.ClassRoomID == classRoomId).Select(g => g.GradeName).FirstOrDefault();
            var subjectList = new List<SubjectVM>();
            var getSubjectList = db.Subjects.Where(y => y.ClassRoomID == classRoomId).ToList();
            foreach(var subject in getSubjectList)
            {
                var subjectDetails = new SubjectVM();
                subjectDetails.SubjectName = subject.SubjectName;
                subjectDetails.Mark = getSubjectTotal(subject.SubjectID, termId, studentId);
                subjectDetails.Average = getSubjectAverage(subject.SubjectID, termId, classRoomId);
                subjectDetails.Comment = getComment(subjectDetails.Mark);
                subjectList.Add(subjectDetails);
            }
            report.subjectList = subjectList;
            return report;
        }
        public string getComment(int mark)
        {
            var comment = "";
           
            if(mark <= 39)
            {
                comment = "Not Performed";
            }
            else if(mark >= 40 && mark <= 49)
            {
                comment = "Poor";
            }
            else if (mark >= 50 && mark <= 59)
            {
                comment = "Adequate";
            }
            else if (mark >= 60 && mark <= 69)
            {
                comment = "Satisfactory";
            }
            else if (mark >= 70 && mark <= 79)
            {
                comment = "Good";
            }
            else if (mark >= 80 )
            {
                comment = "Excellent";
            }
            return comment;
        }
    }
}