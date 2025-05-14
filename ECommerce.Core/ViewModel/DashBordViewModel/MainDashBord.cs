namespace ECommerce.ViewModel.DashBordViewModel
{
    public class MainDashBord
    {
        public decimal TotalSales { set; get; }
        public int TotalOrders { set; get; }
        public int TotalProducts { set; get; }
        public int TotalCustomers { set; get; }

        public List<DataForGraph> salesPerDayForMonth { set; get; }

        public List<recentOfOrders> ordersInfo { set; get; }
        
    }

    public class recentOfOrders
    {
        public long Id { get; set; }
        public string Customer { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
    }
}
