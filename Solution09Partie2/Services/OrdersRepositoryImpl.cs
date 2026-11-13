using Solution09Partie2.Models;

namespace Solution09Partie2.Services
{
    public class OrdersRepositoryImpl : IOrdersRepository
    {
        private readonly ShoppingDbContext context;

        public OrdersRepositoryImpl(ShoppingDbContext context)
        {
            this.context = context;
        }

        public TblOrder? AddNewOrder(TblOrder order)
        {
            //tester que la quantité commandée est dispo
            var availableProduct = context.TblProducts.FirstOrDefault(p => p.ProductId == order.ProductId);
            if (availableProduct != null)
            {
                if (availableProduct.StockQuantity >= order.OrderQuantity)
                {
                    var newOrder = context.TblOrders.Add(order).Entity;
                    availableProduct.StockQuantity -= order.OrderQuantity;
                    context.TblProducts.Update(availableProduct);
                    context.SaveChanges();
                    return newOrder;
                }
            }
            return null;
        
        }

        public List<TblOrder> GetAllOrdersFor(int customerId)
        {
            var existedCustomer = context.TblCustomers.Find(customerId);
            if (existedCustomer != null)
            {
                var orders = context.TblOrders.Where(o => o.CustomerId == customerId).ToList();
                 return orders;
                
            }
            return null;
        }
    }
}
