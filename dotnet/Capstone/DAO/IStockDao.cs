using Capstone.Models;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IStockDao
    {
        public IList<Stock> GetStocksByPlayerId(int id);
    }
}
