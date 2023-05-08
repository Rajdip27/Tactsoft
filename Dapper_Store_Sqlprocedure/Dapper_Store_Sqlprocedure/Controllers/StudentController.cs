using CoreApiResponse;
using Dapper_Store_Sqlprocedure.Models;
using Dapper_Store_Sqlprocedure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dapper_Store_Sqlprocedure.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : BaseController
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return CustomResult("Data load successfully.", await _studentRepository.GetAll());
            }catch (Exception ex)
            {
                return CustomResult(ex.Message, System.Net.HttpStatusCode.BadRequest);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var data = await _studentRepository.GetById(id);
                return CustomResult("Data load successfully.", data);

            }catch(Exception ex)
            {
                return CustomResult(ex.Message, System.Net.HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            try
            {
              bool isSaved=  await _studentRepository.Create(student);
                if (isSaved) 
                return CustomResult("Student has been saved.", student);
                return CustomResult("Student modified failed.", System.Net.HttpStatusCode.BadRequest);
            }catch(Exception ex)
            {
                return CustomResult(ex.Message, System.Net.HttpStatusCode.BadRequest);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(Student student)
        {
            try
            {
                if (student == null)
                {
                    return CustomResult("data not found",System.Net.HttpStatusCode.BadRequest);
                }
                bool isUpdate=await _studentRepository.Update(student);
                if (isUpdate)
                    return CustomResult("Student has been modified.", student);
                return CustomResult("Student modified failed.",System.Net.HttpStatusCode.BadRequest) ;

            }catch (Exception ex)
            {
                return CustomResult(ex.Message, System.Net.HttpStatusCode.BadRequest);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
               
               bool isDelete= await _studentRepository.Delete(id);
                if (isDelete)
                    return CustomResult("Student has been deleted.");
                return CustomResult("Student deleted failed.", System.Net.HttpStatusCode.BadRequest);
            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, System.Net.HttpStatusCode.BadRequest);
            }
        }

    }
}
