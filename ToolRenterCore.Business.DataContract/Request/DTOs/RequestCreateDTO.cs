using System;
using System.Collections.Generic;
using System.Text;

namespace ToolRenterCore.Business.DataContract.Request.DTOs
{
    public class RequestCreateDTO
    {
        public int EquipmentEntityId { get; set; }
        public DateTimeOffset BeginningDateRequestedUtc { get; set; }
        public DateTimeOffset EndingDateRequestedUtc { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public int OwnerId { get; set; }
    }
}
