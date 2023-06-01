using ERPSchool.Models;
using ERPSchool.ViewModels;
using ERPSchool.IManager;
using Microsoft.AspNetCore.Mvc;
using ERPSchool.Helpers;

namespace ERPSchool.Controllers
{
    public class GroupController : BaseController<GroupViewModel, Group>
    {
        private readonly IGroupManager _manager;

        public GroupController(IGroupManager manager) : base(manager)
        {
            _manager = manager;
        }

        public override IActionResult Index() => base.Index();

        [HttpGet]
        public override IActionResult GetAll() => base.GetAll();

        [HttpGet]
        public override IActionResult GetById(int id) => base.GetById(id);

        [HttpPost]
        public override IActionResult Add(GroupViewModel group) => base.Add(group);

        [HttpPatch]
        public override IActionResult Update(int id, GroupViewModel group) => base.Update(id, group);

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
            catch (Exception ex)
            {
                result.Success = 0;
                result.Detail = new { Error = ex.Message };
            }

            return Json(result);
        }
    }
}
