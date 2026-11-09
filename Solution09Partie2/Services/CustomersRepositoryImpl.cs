using Microsoft.EntityFrameworkCore;
using Solution09Partie2.Models;

namespace Solution09Partie2.Services
{
    public class CustomersRepositoryImpl : ICustomersRepository
    {
        private readonly ShoppingDbContext context;

        public CustomersRepositoryImpl(ShoppingDbContext context)
        {
            this.context = context;
        }

        public List<TblCustomer> GetAll()
        {
            return context.TblCustomers.ToList();
        }

        public TblCustomer? GetById(int id)
        {
            return context.TblCustomers.FirstOrDefault( c => c.CustomerId == id);
        }

        public TblCustomer Add(TblCustomer customer)
        {
            var newCustromer = context.TblCustomers.Add(customer).Entity; //Entity retourne toute le ressource nouvellement créée
            context.SaveChanges();
            return newCustromer;
        }

        public TblCustomer DeleteById(int id)
        {
            throw new NotImplementedException();
        }
       
        public TblCustomer Update(TblCustomer customer)
        {
            var existedCustomer = context.TblCustomers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
            if (existedCustomer != null)
            {
                existedCustomer.CustomerName = customer.CustomerName;
                existedCustomer.City = customer.City;
                existedCustomer.CreationDate = customer.CreationDate;

                var updateCustomer = context.TblCustomers.Update(existedCustomer).Entity; //Entity retourne toute le ressource nouvellement créée
                context.SaveChanges();
                return updateCustomer;
            }
            return null;
        }
    }
}
