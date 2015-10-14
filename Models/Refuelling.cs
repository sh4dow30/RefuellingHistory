using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sh4dow.RefuellingHistory.Models
{
    public class Refuelling
    {
        public int ID { get; set; }
        public int CarID { get; set; }
        public int Mileage { get; set; }
        public decimal FuelAmount { get; set; }
        [Column(TypeName = "Money")]
        public decimal Cost { get; set; }

        public DateTime Date { get; set; }
    }
}