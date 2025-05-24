using StudentAPI.Model.DTO;
using StudentAPI.Model;
using StudentAPI.Model.ENUM;

namespace StudentAPI.BL.Interface
{
    public interface IBLStudentHandler : ICommonHandler<StudentDTO>
    {
        

        // add stucent
        public Response AddStundent(StudentDTO dtoStudent);

        // get all students
        public Response GetAllStudents();

        // get student by id
        public Response GetStudentById(int id);

        // update student

        public Response UpdateStudent(int id, StudentDTO dtoStudent);

        // delete student

        public Response DeleteStudent(int id);

        // pre save check all method
        //Response PreSave(StudentDTO studentDTO);

        

    }
}
