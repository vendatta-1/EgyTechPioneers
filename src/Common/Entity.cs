using System;
using System.Collections.Generic;
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
        public bool? IsNotactive { get; set; } = false;

        public string? CreateUserId { get; set; }

        public string? CreateUserName { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public string? Modifiedby { get; set; }

        public DateTime? Modifieddate { get; set; }

        public bool? Isdeleted { get; set; } = false;

        public string? Deletedby { get; set; }

        public DateTime? DeletedDate { get; set; }
    }
}
