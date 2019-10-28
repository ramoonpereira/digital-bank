using DigitalBank.Migrations.Models.AdministratorPermission;
using DigitalBank.Migrations.Models.CustomerPermission;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Migrations.Models.Permission
{
    [Table("permissions")]
    public class PermissionModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("module")]
        public string Module { get; set; }

        [Column("permissions")]
        public string Permissions { get; set; }

        [Column("type")]
        public PermissionTypeEnum Type { get; set; }

        [Column("created")]
        public bool Created { get; set; }

        [Column("created_at")]
        public DateTime CreatedDate { get; set; }

        [NotMapped]
        public virtual ICollection<AdministratorPermissionModel> AdministratorPermissions { get; set; }

        [NotMapped]
        public virtual ICollection<CustomerPermissionModel> CustomerPermissions { get; set; }
    }
}
