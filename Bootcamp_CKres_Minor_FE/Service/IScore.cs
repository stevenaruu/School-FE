using Bootcamp_CKres_Minor.Input;
using Bootcamp_CKres_Minor.Output;

namespace Bootcamp_CKres_Minor_FE.Service
{
    public interface IScore
    {
        Task<GenderOutput> getGenderList();
        Task<GradeOutput> getGradeList();
        Task<ReligionOutput> getReligionList();
        Task<StatusOutput> createStudent(StudentInput? data);
        Task<StudentOutput> getStudentDetail(string id);
        Task<SubjectOutput> getSubjectOutputList();
    }
}
