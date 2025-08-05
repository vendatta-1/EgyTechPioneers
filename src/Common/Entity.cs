using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public abstract class Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; init; }
        public bool IsNotActive { get; set; } = false;

        public string? CreateUserId { get; set; }

        [MaxLength(100)]
        public string? CreateUserName { get; set; }

        public DateTime? CreateDateTime { get; set; }

        [MaxLength(100)]
        public string? ModifiedBy { get; set; }

        
        public DateTime? ModifiedDate { get; set; }

        public bool IsDeleted { get; set; } = false;

        [MaxLength(100)]
        public string? DeletedBy { get; set; } = null;

        public DateTime? DeletedDate { get; set; }
    }
}
