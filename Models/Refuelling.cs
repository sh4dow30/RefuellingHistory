using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;

namespace Sh4dow.RefuellingHistory.Models
{
    public class Refuelling : EntityBase
    {
        private bool _isFullRefuelling = true;
        public int ID { get; set; }
        public int CarID { get; set; }
        public int Mileage { get; set; }
        public decimal FuelAmount { get; set; }
        [Column(TypeName = "Money")]
        public decimal Cost { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Date { get; set; }

        public bool IsFullRefuelling
        {
            get { return _isFullRefuelling; }
            set { _isFullRefuelling = value; }
        }

        private Refuelling GetPriorRefuelling()
        {
            RefuellingHistoryDbContext context = this.GetDbContextFromEntity() as RefuellingHistoryDbContext;
            if (context != null)
            {
                var priorRefuelling =
                    context.Refuellings.Where(r => r.Mileage < Mileage)
                        .OrderByDescending(r => r.Mileage)
                        .FirstOrDefault();
            }
            throw new InvalidOperationException("Cannot get context for this entity");
        }

        public int ComputeMileageSinceLastRefuelling()
        {
            var priorRefuelling = GetPriorRefuelling();
            if (priorRefuelling != null)
            {
                return Mileage - priorRefuelling.Mileage;
            }
            return -1;
        }

        public string ComputeMileageSinceLastRefuellingString()
        {
            var mileage = ComputeMileageSinceLastRefuelling();
            return mileage == -1 ? "-" : mileage.ToString();
        }

        public decimal ComputeFuelConsumption()
        {
            int lastMileage = ComputeMileageSinceLastRefuelling();
            if (lastMileage >= 0 && IsFullRefuelling)
            {
                return (100m * FuelAmount) / (decimal)lastMileage;
            }
            return -1;
        }

        public string ComputeFuelConsumptionString()
        {
            decimal consumption = ComputeFuelConsumption();
            return consumption == -1 ? "-" : string.Format("{0:0.00} l/100km", consumption);
        }
    }
}