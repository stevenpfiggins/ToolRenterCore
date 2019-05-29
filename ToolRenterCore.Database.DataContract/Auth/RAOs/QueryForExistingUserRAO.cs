using System;
using System.Collections.Generic;
using System.Text;

namespace ToolRenterCore.Database.DataContract.Auth.RAOs
{
    public class QueryForExistingUserRAO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
