using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace T5._0.Models
{
    public class Request
    {
        [Key]
        public int RequestId { get; set; }
        public int MobileNumber { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
