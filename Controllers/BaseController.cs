using ERPSchool.Helpers;
using ERPSchool.IManager;
using Microsoft.AspNetCore.Mvc;

namespace ERPSchool.Controllers
{
    public class BaseController<VM, E> : Controller where VM : class where E : class
    {
        private readonly IBaseManager<VM, E> _manager;

        public BaseController(IBaseManager<VM, E> manager)
        {
            _manager = manager;
        }

        public virtual IActionResult Index() { return View(); }

        [HttpGet]
        public virtual IActionResult GetAll()
        {
            var result = new JsonMessageResult();

            try
            {
                result.Success = 1;
                result.Detail = new { Entities = _manager.GetAll() };
            }
            catch (Exception ex)
            {
                result.Success = 0;
                result.Detail = new { Error = ex.Message };
            }

            return Json(result);
        }

        [HttpGet]
        public virtual IActionResult GetById(int id)
        {
            var result = new JsonMessageResult();

            try
            {
                result.Success = 1;
                result.Detail = new { Entity = _manager.GetById(id) };
            }
            catch (Exception ex)
            {
                result.Success = 0;
                result.Detail = new { Error = ex.Message };
            }

            return Json(result);
        }

        [HttpPost]
        public virtual IActionResult Add(VM viewModel)
        {
            var result = new JsonMessageResult();

            try
            {
                _manager.Add(viewModel);

                result.Success = 1;
                result.Detail = new { Message = "¡El registro se creó exitosamente!" };
            }
            catch (Exception ex)
            {
                result.Success = 0;
                result.Detail = new { Error = ex.Message };
            }

            return Json(result);
        }

        [HttpPatch]
        public virtual IActionResult Update(int id, VM viewModel)
        {
            var result = new JsonMessageResult();

            try
            {
                _manager.Update(id, viewModel);

                result.Success = 1;
                result.Detail = new { Message = "¡El registro fue actualizado!" };
            }
            catch (Exception ex)
            {
                result.Success = 0;
                result.Detail = new { Error = ex.Message };
            }

            return Json(result);
        }

        [HttpDelete]
        public virtual IActionResult Delete(int id)
        {
            var result = new JsonMessageResult();

            try
            {
                _manager.Delete(id);

                result.Success = 1;
                result.Detail = new { Message = "¡El registro fue eliminado!" };
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
