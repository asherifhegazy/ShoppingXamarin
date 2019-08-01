using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopApp.Services
{
    public interface IOrderService
    {

        Task<bool> SubmitOrder(int uid);
    }
}
