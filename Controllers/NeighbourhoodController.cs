using ERPSchool.Helpers;
using ERPSchool.IManager;
using ERPSchool.Manager;
using ERPSchool.Models;
using ERPSchool.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace ERPSchool.Controllers
{
    public class NeighbourhoodController : BaseController<NeighbourhoodViewModel, Neighbourhood>
    {
        private readonly INeighbourhoodManager _manager;

        public NeighbourhoodController(INeighbourhoodManager manager) : base(manager)
        {
            _manager = manager;
        }

        public override IActionResult Index() => base.Index();

        [HttpGet]
        public override IActionResult GetAll() => base.GetAll();

        [HttpGet]
        public override IActionResult GetById(int id) => base.GetById(id);

        [HttpPost]
        public override IActionResult Add(NeighbourhoodViewModel neighbourhood) => base.Add(neighbourhood);

        [HttpPatch]
        public override IActionResult Update(int id, NeighbourhoodViewModel neighbourhood) => base.Update(id, neighbourhood);

        [HttpDelete]
        public override IActionResult Delete(int id) => base.Delete(id);


        //[HttpPost]
        //public IActionResult GetByFilter(string filter)
        //{
        //    var result = new JsonMessageResult();

        //    try
        //    {
        //        result.Success = 1;
        //        result.Detail = new { Neighborhoods = _manager.GetByFilter(filter) };
        //    }
        //    catch(Exception ex)
        //    {
        //        result.Success = 0;
        //        result.Detail= new { Error = ex.Message };
        //    }

        //    return Json(result);
        //}

        [HttpGet]
        public IActionResult GetByTownId(int townId)
        {
            var result = new JsonMessageResult();

            try
            {
                result.Success = 1;
                result.Detail = new { Entities = _manager.GetByTownId(townId) };
            }
            catch (Exception ex)
            {
                result.Success = 0;
                result.Detail = new { Error = ex.Message };
            }

            return Json(result);
        }

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
