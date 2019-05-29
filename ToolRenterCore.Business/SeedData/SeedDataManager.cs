using System;
using System.Collections.Generic;
using System.Text;
using ToolRenterCore.Business.DataContract.SeedData;
using ToolRenterCore.Database.DataContract.SeedData;

namespace ToolRenterCore.Business.SeedData
{
    public class SeedDataManager : ISeedDataManager
    {
        private ISeedRepository _seedRepository;

        public SeedDataManager(ISeedRepository seedRepository)
        {
            _seedRepository = seedRepository;
        }

        public void SeedUsers()
        {
            _seedRepository.SeedUsers();
        }
    }
}
