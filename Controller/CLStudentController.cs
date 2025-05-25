using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.BL.Interface;
using StudentAPI.Model;
using StudentAPI.Model.DTO;
using StudentAPI.Model.ENUM;


namespace StudentAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLStudentController : ControllerBase
    {
        /// <summary>
        /// get and set response
        /// </summary>
        private Response _objResponse;

        private IBLStudentHandler _objStudentHandler;



        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="objResponse">Response</param>
        /// <param name="objStudentHandler">Student handler</param>
        public CLStudentController(IBLStudentHandler objStudentHandler)
        {

            _objStudentHandler = objStudentHandler;
        }


        /// <summary>
        /// Get all student
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllStudent")]
        public IActionResult GetAllStudent()
        {
            // get response for all sstudent 
            _objResponse = _objStudentHandler.GetAllStudents();

            // return response 
            return Ok(_objResponse);
        }

        [HttpGet]
        [Route("getStudentByid")]
        public IActionResult GetStudent(int id)
        {
            // get student by id record 
            _objResponse = _objStudentHandler.GetStudentById(id);

            return Ok(_objResponse);

        }


        [HttpPost]
        [Route("AddStudent")]

        public IActionResult AddStudent(StudentDTO ObjStudentDTO)
        {
            // operation type
            _objStudentHandler.typeOfOperation = OperationType.A;

            // presave method 
            _objStudentHandler.PreSave(ObjStudentDTO);

            if (_objResponse == null)
            {
                _objResponse = new Response();  // Empty response object
                _objResponse.IsError = false;   // Default safe value
            }


            // if not any error 
            if (!_objResponse.IsError)
            {
                // save method
                _objResponse = _objStudentHandler.Save();
            }

            // return response
            return Ok(_objResponse);
        }

        [HttpPut]
        [Route("UpdateStudent")]
        public IActionResult UpdateStudent(int id, StudentDTO ObjStudentDTO)
        {
            // operation type
            _objStudentHandler.typeOfOperation = OperationType.U;
            // presave method 
            _objStudentHandler.PreSave(ObjStudentDTO);

            if (_objResponse == null)
            {
                _objResponse = new Response();  // Empty response object
                _objResponse.IsError = false;   // Default safe value
            }

            // if not any error 
            if (!_objResponse.IsError)
            {
                // save method
                _objResponse = _objStudentHandler.Save();
            }
            // return response
            return Ok(_objResponse);
        }


        [HttpDelete]
        [Route("DeleteStudent")]
        public IActionResult DeleteStudent(int id)
        {
            // operation type
            _objStudentHandler.typeOfOperation = OperationType.D;

            if (_objResponse == null)
            {
                _objResponse = new Response();  // Empty response object
                _objResponse.IsError = false;   // Default safe value
            }

            // if not any error 
            if (!_objResponse.IsError)
            {
                // save method
                _objResponse = _objStudentHandler.DeleteStudent(id);
            }

            // return response
            return Ok(_objResponse);
        }
    }
}
