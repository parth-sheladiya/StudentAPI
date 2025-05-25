using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using StudentAPI.BL.Interface;
using StudentAPI.Extension;
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
            if (!IsUSRExist(_id))
            {
                _objResponse.IsError = true;
                _objResponse.Message = "Student not found";
                return _objResponse;
            }
            using (IDbConnection db = _dbfactory.OpenDbConnection())
            {
                // delete record by id
                db.DeleteById<Student>(id);
            }
            _objResponse.IsError = false;
            _objResponse.Message = "Record deleted successfully.";
            return _objResponse;
        }

        public Response GetAllStudents()
        {
            // list 

            List<Student> res = new List<Student>();

            using (IDbConnection db = _dbfactory.OpenDbConnection())
            {
                // Fetch Student record 
                 res = db.Select<Student>();
            }

            if(res != null && res.Count > 0)
            {
                _objResponse.Data = res;
                _objResponse.IsError = false;
                _objResponse.Message = "Data fetched successfully.";
            }
            else
            {
                _objResponse.IsError = true;
                _objResponse.Message = "No data found.";
            }

            return _objResponse;
        }

        public Response GetStudentById(int id)
        {
            using (IDbConnection db = _dbfactory.OpenDbConnection())
            {
                // Fetch Student record by id
                objStudent = db.SingleById<Student>(id);
            }

            if (objStudent != null)
            {
                _objResponse.Data = objStudent;
                _objResponse.IsError = false;
                _objResponse.Message = "Data fetched successfully.";
            }
            else
            {
                _objResponse.IsError = true;
                _objResponse.Message = "No data found for the given id.";
            }

            return _objResponse;

        }

        public void PreSave(StudentDTO objDto)
        {
            // convert dto to poco 
            objStudent = objDto.ToPoco();


            // set id if not exists
            if (typeOfOperation == OperationType.U || typeOfOperation == OperationType.D)
            {
                _id = objDto.id;
            }
            

        }

        public bool IsUSRExist(int id)
        {
            using (var db = _dbfactory.OpenDbConnection())
            {
                return db.Exists<Student>(id);
            }
        }
        public Response Save()
        {
            using(IDbConnection db = _dbfactory.OpenDbConnection())
            {
                // check operation type
                if (typeOfOperation == OperationType.A)
                {
                    // insert record
                    db.Insert(objStudent);
                    _objResponse.IsError = false;
                    _objResponse.Message = "Record added successfully.";
                }
                else if (typeOfOperation == OperationType.U)
                {
                    if (!IsUSRExist(_id))
                    {
                        _objResponse.IsError = true;
                        _objResponse.Message = "Student not found";
                        return _objResponse;
                    }
                    // update record
                    db.Update(objStudent);
                    _objResponse.IsError = false;
                    _objResponse.Message = "Record updated successfully.";
                }
                
            }

            return _objResponse;
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
