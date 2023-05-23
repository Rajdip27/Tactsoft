using Master_Details_JQure.DatabaseContext;
using Master_Details_JQure.Models;
using Master_Details_JQure.Service.Base;
using Microsoft.EntityFrameworkCore;

namespace Master_Details_JQure.Service
{
    public class PurchaseService : BaseService<Purchase>, IPurchaseService
    {
        private readonly ApplicationDbContext _context;
        public PurchaseService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Task DeleteRangeAsync(Purchase purchase)
        {
            List<PurchaseItem> purchaseItems = _context.PurchasesItems.Where(x => x.PurchaseId == purchase.Id).ToList();
            _context.PurchasesItems.RemoveRange(purchaseItems);
            _context.SaveChanges();

            _context.Attach(purchase);
            _context.Entry(purchase).State = EntityState.Deleted;
            _context.SaveChanges();

            return Task.CompletedTask;
        }

        public Purchase GetItems(long id)
        {
            Purchase item = _context.Purchases.Where(x => x.Id == id).Include(i => i.PurchaseItems).ThenInclude(i => i.Item).FirstOrDefault();
            item.PurchaseItems.ForEach(x => x.Amount = x.Quantity * x.PurchasePrice);
            return item;
        }

        public Task UpdateRangeAsync(Purchase purchase)
        {
            List<PurchaseItem> purchaseItems = _context.PurchasesItems.Where(x => x.PurchaseId == purchase.Id).ToList();
            _context.PurchasesItems.RemoveRange(purchaseItems);
            _context.SaveChanges();
            _context.Attach(purchase);
            _context.Entry(purchase).State = EntityState.Modified;
            _context.PurchasesItems.AddRange(purchase.PurchaseItems);
            _context.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
