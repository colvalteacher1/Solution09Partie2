using Solution09Partie2.Models;

namespace Solution09Partie2.Services
{
    public interface ICustomersRepository
    {
        List<TblCustomer> GetAll();
        TblCustomer? GetById(int id);
        TblCustomer Add(TblCustomer customer);
        TblCustomer Update(TblCustomer customer);
        TblCustomer DeleteById(int id);

    }
}
