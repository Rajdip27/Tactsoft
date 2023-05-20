using jQuery_Ajax_CRUD.DatabaseContext;
using jQuery_Ajax_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace jQuery_Ajax_CRUD.Controllers
{
	public class TransactionController : Controller
	{
		private readonly ApplicationDbContext _context;
        public TransactionController(ApplicationDbContext context)
        {
			_context = context;
        }
		[HttpGet]
        public async Task< IActionResult> Index()
		{
			var data = await _context.Transactions.ToListAsync();


            return View(data);
		}
		[HttpGet]
		public async Task<IActionResult> AddOrEdit(int id=0)
		{
			if(id == 0)
			{
				return View(new TransactionModel());
			}
			else
			{
				var transactionModel= await _context.Transactions.FindAsync(id);
				if(transactionModel == null)
				{
					return NotFound();
				}
				return View(transactionModel);
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddorEdit(int id, [Bind("TransactionId,AccountNumber,BeneficiaryName,BankName,SWIFTCode,Amount,Date")]TransactionModel transactionModel)
		{
			if (ModelState.IsValid)
			{
				//insert
				if (id == 0)
				{
					transactionModel.Date = DateTime.Now;
					_context.Add(transactionModel);
					await _context.SaveChangesAsync();
				}
				//update
				else
				{
					try
					{
						_context.Update(transactionModel);
						await _context.SaveChangesAsync();
					}
                    catch (Exception ex)
                    {
						return View(ex.Message);
                    }

                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index", _context.Transactions).ToList() });
            }

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", transactionModel) });
        }
		public async Task<IActionResult> Delete(int? id) 
		{ 
			if(id== null)
			{
				return NotFound();
			}
			var data =await _context.Transactions.FindAsync(id);
			if(data == null)
			{
				return NotFound();
			}
			return View(data);
		}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transactionModel = await _context.Transactions.FindAsync(id);
            _context.Transactions.Remove(transactionModel);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "Index", _context.Transactions.ToList()) });
        }

        private bool TransactionModelExists(int id)
        {
            return _context.Transactions.Any(e => e.TransactionId == id);
        }
    }
}
		


