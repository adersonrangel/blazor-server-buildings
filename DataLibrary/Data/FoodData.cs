using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Db;
using DataLibrary.Models;

namespace DataLibrary.Data
{
    public class FoodData : IFoodData
    {
        private readonly IDataAccess _dbAccess;
        private readonly ConnectionStringData _connectionString;

        public FoodData(IDataAccess dbAccess , ConnectionStringData connectionString)
        {
            _dbAccess = dbAccess;
            _connectionString = connectionString;
        }

        public Task<List<FoodModel>> GetFood()
        {
            return _dbAccess
                .LoadData<FoodModel, dynamic>("dbo.spFood_All",
                    new
                    {
                    },
                    _connectionString.SqlConnectionName);
        }
    }
}
