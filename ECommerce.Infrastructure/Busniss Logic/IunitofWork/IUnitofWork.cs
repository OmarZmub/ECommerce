using ECommerce.Busniss_Logic.IunitofWork.IRepo;
using ECommerce.Data.Models;
public interface IUnitofWork : IDisposable
{
    //Custom Repo
    IUserRepositry UserRepo { get; }


    //Generic Repo
    IMainrepositry<Address> AddressRepo { get; }
    IMainrepositry<BankFee> BankFeeRepo { get; }
    IMainrepositry<Cart> CartRepo { get; }
    IMainrepositry<Category> CategoryRepo { get; }
    IMainrepositry<Discount> DiscountRepo { get; }
    IMainrepositry<DiscountType> DiscountTypeRepo { get; }
    IMainrepositry<Order> OrderRepo { get; }
    IMainrepositry<OrderItem> OrderItemRepo { get; }
    IMainrepositry<OrderStatus> OrderStatusRepo { get; }
    IMainrepositry<PaymentDetail> PaymentDetailRepo { get; }
    IMainrepositry<PaymentMethod> PaymentMethodRepo { get; }
    IMainrepositry<PaymentStatus> PaymentStatusRepo { get; }
    IMainrepositry<Product> ProductRepo { get; }
    IMainrepositry<ProductImage> ProductImageRepo { get; }
    IMainrepositry<Review> ReviewRepo { get; }
    IMainrepositry<ShippingRegion> ShippingRegionRepo { get; }
    IMainrepositry<StockMovement> StockMovementRepo { get; }



}
