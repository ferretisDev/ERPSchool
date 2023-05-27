using Microsoft.AspNetCore.Mvc;
using ERPSchool.Helpers;
using ERPSchool.ViewModels;
using ERPSchool.IManager;
using ERPSchool.Models;

namespace ERPSchool.Controllers
{
    public class TownController : BaseController<TownViewModel, Town>
    {
        private readonly ITownManager _manager;

        public TownController(ITownManager manager): base(manager)
        {
            _manager = manager;
        }

        public override IActionResult Index() => base.Index();

        [HttpGet]
        public override IActionResult GetAll() => base.GetAll();

        [HttpGet]
        public override IActionResult GetById(int id) => base.GetById(id);

        [HttpPost]
        public override IActionResult Add(TownViewModel town) => base.Add(town);

        [HttpPatch]
        public override IActionResult Update(int id, TownViewModel town) => base.Update(id, town);

        [HttpDelete]
        public override IActionResult Delete(int id) => base.Delete(id);

        [HttpGet]
        public IActionResult GetByStateId(int stateId)
        {
            var result = new JsonMessageResult();

            try
            {
                result.Success = 1;
                result.Detail = new { Entities = _manager.GetByStateId(stateId) };
            }
            catch (Exception ex)
            {
                result.Success = 0;
                result.Detail = new { Error = ex.Message };
            }

            return Json(result);
        }

        [HttpGet]
        public IActionResult GetDetailById(int id) { 
        
            var result = new JsonMessageResult();

            try
            {
                result.Success = 1;
                result.Detail = new { Town = _manager.GetDetailById(id) };
            }
            catch(Exception ex)
            {
                result.Success=0;
                result.Detail= new { Error = ex.Message };
            }

            return Json(result);
        }
        
        [HttpGet]
        public IActionResult GetAllDetails() { 
        
            var result = new JsonMessageResult();

            try
            {
                result.Success = 1;
                result.Detail = new { Towns = _manager.GetAllDetails() };
            }
            catch(Exception ex)
            {
                result.Success=0;
                result.Detail= new { Error = ex.Message };
            }

            return Json(result);
        }
    }
}