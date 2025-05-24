using ServiceStack.Data;
using ServiceStack.OrmLite;
using StudentAPI.BL.Interface;
using StudentAPI.Model;
using StudentAPI.Model.DTO;
using StudentAPI.Model.ENUM;
using StudentAPI.Model.POCO;
using System.Data;

namespace StudentAPI.BL.Operations
{
    public class BLStudentHandler : IBLStudentHandler
    {
        // connection factory 

        private readonly IDbConnectionFactory _dbfactory;

        // response 

        private Response _objResponse;
        // id 
        public int _id;

        // poco model
        private Student objStudent;

        // enum type operation
        public OperationType typeOfOperation { get; set;}

        
        public BLStudentHandler(IDbConnectionFactory dbfactory , Response objResponse)
        {
            // initialize connection factory
            _dbfactory = dbfactory;
            _objResponse = objResponse;
        }   

        public Response AddStundent(StudentDTO dtoStudent)
        {
            throw new NotImplementedException();
        }

        public Response DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public Response GetAllStudents()
        {
            using (IDbConnection db = _dbfactory.OpenDbConnection())
            {
                // Fetch Student record 
                List<Student> res = db.Select<Student>();
            }

            if(res)

            return _objResponse;
        }

        public Response GetStudentById(int id)
        {
            throw new NotImplementedException();
        }

        public void PreSave(StudentDTO objDto)
        {
            throw new NotImplementedException();
        }

        public Response Save()
        {
            throw new NotImplementedException();
        }

        public Response UpdateStudent(int id, StudentDTO dtoStudent)
        {
            throw new NotImplementedException();
        }

        public Response Validation()
        {
            throw new NotImplementedException();
        }
    }
}
