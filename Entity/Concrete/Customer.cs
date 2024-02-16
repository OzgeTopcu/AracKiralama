using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public virtual User User { get; set; }
    }
}
