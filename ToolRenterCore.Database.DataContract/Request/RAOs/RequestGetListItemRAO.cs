using System;
using System.Collections.Generic;
using System.Text;

namespace ToolRenterCore.Database.DataContract.Request.RAOs
{
    public class RequestGetListItemRAO
    {
        public int RequestEntityId { get; set; }
        public int OwnerId { get; set; }
        public int EquipmentEntityId { get; set; }
        public DateTimeOffset BeginningDateRequestedUtc { get; set; }
        public DateTimeOffset EndingDateRequestedUtc { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset UpdatedUtc { get; set; }
    }
}
