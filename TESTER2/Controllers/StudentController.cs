using DataProvider.IProvider;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Request;

namespace TESTER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public readonly IStudentProvider _studentProvider;
        public StudentController(IStudentProvider studentProvider)
        {
            _studentProvider = studentProvider;
        }

        #region Students

        [HttpGet("GetAllStudents")]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var students = await _studentProvider.studentRepo.GetAllStudents();
                if (students != null)
                {
                    return Ok(new { status = "success", data = students, message = "تم بنجاح" });
                }
                else
                {
                    return NotFound(new { status = "error", message = "لم يتم العثور على الطلاب" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = "error", message = "حدث خطأ برجاء المحاولة في وقت لاحق", exception = ex.Message });
            }
        }


        [HttpPost("GetStudentById")]
        public async Task<IActionResult> GetStudentById(StudentReq request)
        {
            try
            {
                var student = await _studentProvider.studentRepo.GetStudentById(request);
                if (student != null)
                {
                    return Ok(new { status = "success", data = student, message = "تم بنجاح" });
                }
                else
                {
                    return NotFound(new { status = "error", message = "الطالب غير موجود" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = "error", message = "حدث خطأ برجاء المحاولة في وقت لاحق", exception = ex.Message });
            }
        }


        [HttpPost("SaveStudent")]
        public async Task<IActionResult> SaveStudent(SaveStudentsReq saveStudentsReq)
        {
            try
            {
                var status = await _studentProvider.studentRepo.SaveStudent(saveStudentsReq);
                if (status == 1)
                {
                    return Ok(new { status = "success", message = "تم الحفظ بنجاح" });
                }
                else if (status == -1)
                {
                    return BadRequest(new { status = "error", message = "حدث خطأ برجاء المحاولة في وقت لاحق" });
                }
                else
                {
                    return BadRequest(new { status = "error", message = "رقم الهوية الذي أرسلته غير موجود" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = "error", message = "حدث خطأ برجاء المحاولة في وقت لاحق", exception = ex.Message });
            }
        }


        [HttpPost("DeleteStudent")]
        public async Task<IActionResult> DeleteStudent(StudentReq studentRequest)
        {
            try
            {
                var isDeleted = await _studentProvider.studentRepo.DeleteStudent(studentRequest);
                if (isDeleted)
                {
                    return Ok(new { status = "success", message = "تم حذف الطالب بنجاح" });
                }
                else
                {
                    return BadRequest(new { status = "error", message = "حدث خطأ برجاء المحاولة في وقت لاحق" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = "error", message = "حدث خطأ برجاء المحاولة في وقت لاحق", exception = ex.Message });
            }
        }

        #endregion
    }
}
