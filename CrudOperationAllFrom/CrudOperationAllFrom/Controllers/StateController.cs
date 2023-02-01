using CrudOperation.Models;
using CrudOperationAllFrom.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CrudOperationAllFrom.Controllers
{
    public class StateController : Controller
    {
        private readonly IState _state;
        public StateController(IState state)
        {
            _state = state;
        }

        public async Task <ActionResult <State>> Index()
        {
            return View(await _state.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
           
           
           
            return View();
        }
        [HttpPost]
        public async Task<ActionResult<State>> create(State state)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _state.Create(state);
                    await _state.Save();
                    return RedirectToAction(actionName:nameof(Index));
                }
                return View(state);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
