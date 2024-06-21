using DataProvider.IProvider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO.Request;
using System.Net;

namespace TESTER2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        public readonly ISchoolProvider _schoolProvider;
        public SchoolController(ISchoolProvider schoolProvider)
        {
            _schoolProvider = schoolProvider;
        }


        #region Schools

        [HttpGet("GetAllSchools")]
        public async Task<IActionResult> GetSchools()
        {
            try
            {
                var schools = await _schoolProvider.schoolRepo.GetAllSchools();
                return Ok(new
                {
                    Status = HttpStatusCode.OK,
                    Data = schools,
                    Message = "تم بنجاح"
                });
            }
            catch
            {
                return BadRequest(new
                {
                    Status = HttpStatusCode.BadRequest,
                    Data = (object)null,
                    Message = "حدث خطأ برجاء المحاولة في وقت لاحق"
                });
            }
        }


        [HttpPost("GetSchoolById")]
        public async Task<IActionResult> GetSchoolById(SchoolRequest request)
        {
            try
            {
                var school = await _schoolProvider.schoolRepo.GetSchoolById(request);
                if (school != null)
                {
                    return Ok(new
                    {
                        Status = HttpStatusCode.OK,
                        Data = school,
                        Message = "تم بنجاح"
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Status = HttpStatusCode.BadRequest,
                        Data = (object)null,
                        Message = "المدرسة غير موجودة"
                    });
                }
            }
            catch
            {
                return BadRequest(new
                {
                    Status = HttpStatusCode.BadRequest,
                    Data = (object)null,
                    Message = "حدث خطأ برجاء المحاولة في وقت لاحق"
                });
            }
        }


        [HttpPost("SaveSchool")]
        public async Task<IActionResult> SaveSchool(SaveSchoolsReq saveSchoolsReq)
        {
            try
            {
                var status = await _schoolProvider.schoolRepo.SaveSchool(saveSchoolsReq);
                if (status == 1)
                {
                    return Ok(new
                    {
                        Status = HttpStatusCode.OK,
                        Data = (object)null,
                        Message = "تم الحفظ بنجاح"
                    });
                }
                else if (status == -1)
                {
                    return BadRequest(new
                    {
                        Status = HttpStatusCode.BadRequest,
                        Data = (object)null,
                        Message = "حدث خطأ برجاء المحاولة في وقت لاحق"
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Status = HttpStatusCode.BadRequest,
                        Data = (object)null,
                        Message = "رقم الهوية الذي أرسلته غير موجود"
                    });
                }
            }
            catch
            {
                return BadRequest(new
                {
                    Status = HttpStatusCode.BadRequest,
                    Data = (object)null,
                    Message = "حدث خطأ برجاء المحاولة في وقت لاحق"
                });
            }
        }


        [HttpPost("DeleteSchool")]
        public async Task<IActionResult> DeleteSchool(SchoolRequest schoolRequest)
        {
            try
            {
                var isDeleted = await _schoolProvider.schoolRepo.DeleteSchool(schoolRequest);
                if (isDeleted)
                {
                    return Ok(new
                    {
                        Status = HttpStatusCode.OK,
                        Data = (object)null,
                        Message = "تم حذف المدرسة بنجاح"
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Status = HttpStatusCode.BadRequest,
                        Data = (object)null,
                        Message = "حدث خطأ برجاء المحاولة في وقت لاحق"
                    });
                }
            }
            catch
            {
                return BadRequest(new
                {
                    Status = HttpStatusCode.BadRequest,
                    Data = (object)null,
                    Message = "حدث خطأ برجاء المحاولة في وقت لاحق"
                });
            }
        }

        #endregion
    }
}
