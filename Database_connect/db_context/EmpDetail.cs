using System;
using System.Collections.Generic;

#nullable disable

namespace Database_connect.db_context
{
    public partial class EmpDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public long? PhoneNo { get; set; }
    }
}
