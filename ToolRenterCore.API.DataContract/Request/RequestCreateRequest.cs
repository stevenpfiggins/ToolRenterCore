using System;
using System.Collections.Generic;
using System.Text;

namespace ToolRenterCore.API.DataContract.Request
{
    public class RequestCreateRequest
    {
        public int EquipmentEntityId { get; set; }
        public DateTimeOffset BeginningDateRequestedUTC { get; set; }
        public DateTimeOffset EndingDateRequestedUTC { get; set; }
    }
}
