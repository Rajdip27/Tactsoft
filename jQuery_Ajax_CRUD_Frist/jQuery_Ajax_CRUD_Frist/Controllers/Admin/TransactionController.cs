using jQuery_Ajax_CRUD_Frist.Models;
using jQuery_Ajax_CRUD_Frist.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static jQuery_Ajax_CRUD_Frist.Helper;

namespace jQuery_Ajax_CRUD_Frist.Controllers.Admin
{
    public class TransactionController : Controller
    {
       private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        public async Task<IActionResult> Index()
        {
          
            var data= await _transactionService.GetAllAsync();
            return View(data);
        }
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if(id == 0)
            {
                return View(new TransactionModel());
            }
            else
            {
                var data= await _transactionService.FindAsync(id);
                if(data == null)
                {
                    return NotFound();
                }
                return View(data);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(long id, TransactionModel model)
        {
            if(ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _transactionService.InsertAsync(model);
                }
                else
                {
                    try
                    {
                        await _transactionService.UpdateAsync(model);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TransactionModelExists(model.Id))
                        { return NotFound(); }
                        else
                        {
                            throw;
                        }
                    }
                   

                }
                var viewAll = Helper.RenderRazorViewToString(this, "_ViewAll", await _transactionService.GetAllAsync()) ;
            return Json(new { isValid = true, html = viewAll });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", model) });

        }
        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _transactionService.FindAsync(id);
            if(data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
          var data = await _transactionService.FindAsync(id);
            if(data == null)
            {
                return NotFound();
            }
            await _transactionService.DeleteAsync(data);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _transactionService.GetAllAsync() )});
        }


        private bool TransactionModelExists(long id)
        {
           return _transactionService.TransactionModelExists(id);
        }
    }
}
