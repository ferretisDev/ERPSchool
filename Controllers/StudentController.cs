using ERPSchool.Models;
using ERPSchool.ViewModels;
using ERPSchool.IManager;
using Microsoft.AspNetCore.Mvc;
using ERPSchool.Helpers;

namespace ERPSchool.Controllers
{
    public class StudentController : BaseController<StudentViewModel, Student>
    {
        private readonly IStudentManager _manager;

        public StudentController(IStudentManager manager) : base(manager)
        {
            _manager = manager;
        }

        public override IActionResult Index() => base.Index();

        [HttpGet]
        public override IActionResult GetAll() => base.GetAll();

        [HttpGet]
        public override IActionResult GetById(int id) => base.GetById(id);

        [HttpPost]
        public override IActionResult Add(StudentViewModel student) => base.Add(student);

        [HttpPatch]
        public override IActionResult Update(int id, StudentViewModel student) => base.Update(id, student);

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
    }
}
