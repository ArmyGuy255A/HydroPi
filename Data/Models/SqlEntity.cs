using HydroPi.Data.Interfaces;
using HydroPi.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HydroPi.Data.Models
{
    public abstract class SqlEntity : ISqlEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        object IEntity.Id
        {
            get { return this.Id; }
        }

        private DateTime? createdDate;

        [DataType(DataType.DateTime)]
        [ScaffoldColumn(false)]
        [Editable(false)]
        public DateTime CreatedDate
        {
            get { return createdDate ?? DateTime.UtcNow; }
            set { createdDate = value; }
        }

        [ScaffoldColumn(false)]
        [Editable(false)]
        public string CreatedBy { get; set; }
        public string Name { get; set; }
    }
}
