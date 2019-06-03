using System;
using System.Collections.Generic;
using System.Text;

namespace ToolRenterCore.API.DataContract.Request
{
    public class RequestGetListItemResponse
    {
        public int RequestEntityId { get; set; }
        public int OwnerId { get; set; }
        public int EquipmentEntityId { get; set; }
        public DateTimeOffset BeginningDateRequestedUTC { get; set; }
        public DateTimeOffset EndingDateRequestedUTC { get; set; }
    }
}
