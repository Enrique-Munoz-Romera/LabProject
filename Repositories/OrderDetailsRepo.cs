using DocumentFormat.OpenXml.Drawing.Charts;
using LabProject.Data;
using LabProject.Models.Customers;
using System.Linq;

namespace LabProject.Repositories
{
    public class OrderDetailsRepo
    {
        SalesContext _context;

        public OrderDetailsRepo(SalesContext context)
        {
            this._context = context;
        }

        public Dictionary<String, int> GetTop5Products()
        {
            var query = from data in this._context.OrderDetail
                        orderby data.Sku
                        select data;
            var orderDetails = query.ToList();

            Dictionary<String, int> dictionary = new Dictionary<string, int>();
            
            for (var i = 100; i <= 1000; i+=100){
                var amount = 0;
                var orderDetailsList = orderDetails.Where(x => x.Sku == i).ToList();
                foreach(var od in orderDetailsList)
                {
                    amount += od.Amount;
                }
                dictionary.Add("SKU" + i.ToString(), amount);
            }
            var a = dictionary.OrderByDescending(x => x.Value).Take(5).ToDictionary(x => x.Key, x => x.Value);
            return a;
        }

    }
}
