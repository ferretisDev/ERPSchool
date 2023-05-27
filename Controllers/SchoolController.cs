using ERPSchool.Helpers;
using ERPSchool.IManager;
using ERPSchool.Manager;
using ERPSchool.Models;
using ERPSchool.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ERPSchool.Controllers
{
    public class SchoolController : BaseController<SchoolViewModel, School>
    {
        private readonly ISchoolManager _manager;

        public SchoolController(ISchoolManager manager) : base(manager)
        {
            _manager = manager;
        }

        public override IActionResult Index() => base.Index();

        [HttpGet]
        public override IActionResult GetAll() => base.GetAll();

        [HttpGet]
        public override IActionResult GetById(int id) => base.GetById(id);

        [HttpPost]
        public override IActionResult Add(SchoolViewModel school) => base.Add(school);

        [HttpPatch]
        public override IActionResult Update(int id, SchoolViewModel school) => base.Update(id, school);

        [HttpDelete]
        public override IActionResult Delete(int id) => base.Delete(id);

        [HttpGet]
        public IActionResult GetAllDetails()
        {
            var result = new JsonMessageResult();

            try
            {
                result.Success = 1;
                result.Detail = new { Entities = _manager.GetAllDetails() };
            }
            catch (Exception ex)
            {
                result.Success = 0;
                result.Detail = new { Error = ex.Message };
            }

            return Json(result);
        }

        [HttpGet]
        public IActionResult GetDetailById(int id)
        {
            var result = new JsonMessageResult();

            try
            {
                result.Success = 1;
                result.Detail = new { Entity = _manager.GetDetailById(id) };
            }
            catch(Exception ex)
            {
                result.Success = 0;
                result.Detail= new { Error = ex.Message };  
            }

            return Json(result);
        }
    }
}
