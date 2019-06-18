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
        public DateTimeOffset BeginningDateRequestedUtc { get; set; }
        public DateTimeOffset EndingDateRequestedUtc { get; set; }
    }
}
