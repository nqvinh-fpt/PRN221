using Microsoft.AspNetCore.SignalR;
using Q2.Models;

namespace Q2.Hubs
{
    public class ProductsHub: Hub
    {
        /*public async Task DeleteProduct(int idProduct)
        {
            if (idProduct > 0)
            {
                await Clients.All.SendAsync("ProductDeleted", idProduct);
            }
        }*/

        private readonly LuyenOnThiDBContext context;

        public ProductsHub(LuyenOnThiDBContext context)
        {
            this.context = context;
        }
    }
}
