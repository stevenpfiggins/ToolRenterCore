﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ToolRenterCore.Business.DataContract.Auth.DTOs
{
    public class QueryForExistingUserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
