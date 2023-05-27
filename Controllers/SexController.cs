using ERPSchool.Helpers;
using ERPSchool.IManager;
using ERPSchool.Models;
using ERPSchool.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ERPSchool.Controllers
{
    public class SexController : BaseController<SexViewModel, Sex>
    {
        private readonly ISexManager _manager;

        public SexController(ISexManager manager) :base(manager)
        {
            _manager = manager;
        }

        public override IActionResult Index() => base.Index();

        [HttpGet]
        public override IActionResult GetAll() => base.GetAll();

        [HttpGet]
        public override IActionResult GetById(int id) => base.GetById(id);

        [HttpPost]
        public override IActionResult Add(SexViewModel sex) => base.Add(sex);

        [HttpPatch]
        public override IActionResult Update(int id, SexViewModel sex) => base.Update(id, sex);

        [HttpDelete]
        public override IActionResult Delete(int id) => base.Delete(id);
    }
}
