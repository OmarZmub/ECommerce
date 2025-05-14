using ECommerce.Data;
using ECommerce.ViewModel;
using ECommerce.ViewModel.DashBordViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers.DashBord
{
    public class MainDashBordController : Controller
    {
        private readonly database _dbcontext;
        private readonly IUnitofWork Logic;
        private readonly MainDashBord _dashBord = new MainDashBord();
        private readonly DataForGraph graph = new DataForGraph();

        public MainDashBordController(database context, IUnitofWork work )
        {
            _dbcontext = context;
            this.Logic = work;
        }
        //[Authorize(Roles = RoleViewModel.RoleAdmin)]
        public async Task<IActionResult> IndexAsync()
        {
            //  This Query To Get Information For 4 Card in DashBord
            _dashBord.TotalSales = await _dbcontext.Orders.SumAsync(o => o.TotalAmount);
            _dashBord.TotalOrders = await _dbcontext.Orders.CountAsync();
            _dashBord.TotalProducts = await _dbcontext.Products.CountAsync();
            _dashBord.TotalCustomers = await _dbcontext.Users.CountAsync();


            // For Graph in Dash Bord
            var now = DateTime.Now;
            var salesPerDay = await _dbcontext.Orders
                .Where(o => o.OrderDate.Month == now.Month && o.OrderDate.Year == now.Year)
                .GroupBy(o => o.OrderDate.Day)
                .Select(g => new DataForGraph
                {
                    Day = g.Key,
                    Total = g.Sum(x => x.TotalAmount)
                })
                .OrderBy(x => x.Day)
                .ToListAsync();
            _dashBord.salesPerDayForMonth = salesPerDay;


            // For Recent Order With Info Of Customer 
            var recentOrders = await _dbcontext.Orders
                    .Include(o => o.User) // Assuming there's a Customer navigation property
                .OrderByDescending(o => o.OrderDate) // Or OrderId if that's sequential
                .Take(10)
                .Select(o => new recentOfOrders
                {
                    Id = o.Id,
                    Customer = o.User.FullName,
                    Total = o.TotalAmount,
                    Status = o.Status.StatusName // e.g., "تم التوصيل"
                })
                .ToListAsync();

                    _dashBord.ordersInfo = recentOrders;

            //ViewBag.OrdersInfo = recentOrders;

            return View(_dashBord);
        }
    }
}
