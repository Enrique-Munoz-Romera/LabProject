using LabProject.Data;
using LabProject.Models;
using LabProject.Models.Customers;
using LabProject.Models.Sales;
using Microsoft.EntityFrameworkCore;

namespace LabProject.Repositories
{
    public class CustomersRepo
    {
        SalesContext _context;
        CustomersContext _contextC;

        public CustomersRepo(SalesContext context, CustomersContext contextC) { 
            this._context = context; 
            this._contextC = contextC; 
        }

        public CustomerSales GetAllSpends()
        {
            var orders = from data in _context.Order
                         .Join(
                            this._context.OrderDetail,
                            o => o.Id,
                            od => od.OrderId,
                            (o, od) => new { Order = o, OrderDetail = od }
                        ).OrderBy(x => x.Order.CustomerId) select data;

            var ordersList = orders.ToList();
            var amountMax = 0.0;
            var customer = new Customer();

            for (var i = 1; i <= ordersList.DistinctBy(x => x.Order.CustomerId).ToList().Count; i++)
            {
                var or = ordersList.Where(x => x.Order.CustomerId == i).ToList();
                var amount = 0.0;
                foreach(var o in or)
                {
                    amount += ((double)o.OrderDetail.Amount * o.OrderDetail.UnitPrice);
                }
                if (amount > amountMax)
                {
                    var query = from datos in this._contextC.Customer
                                where datos.Id == i
                                select datos;
                    customer = query.FirstOrDefault();
                    amountMax = amount;
                }
            }

            var customerResult = new CustomerSales();
            customerResult.Customer = customer;
            customerResult.AmountMax = amountMax;

            return customerResult;
        }
    }
}
