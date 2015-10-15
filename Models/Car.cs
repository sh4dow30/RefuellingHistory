using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sh4dow.RefuellingHistory.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy}")]
        [DataType(DataType.DateTime)]
        public DateTime Year { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<Refuelling> Refuellings { get; set; }
    }
}
