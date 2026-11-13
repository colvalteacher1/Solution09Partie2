using Solution09Partie2.Models;

namespace Solution09Partie2.Services
{
    public interface IOrdersRepository
    {
        TblOrder? AddNewOrder(TblOrder order);
        List<TblOrder> GetAllOrdersFor(int customerId);
    }
}
