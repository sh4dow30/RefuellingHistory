using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sh4dow.RefuellingHistory.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
