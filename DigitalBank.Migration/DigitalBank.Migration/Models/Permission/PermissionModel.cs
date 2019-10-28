using DigitalBank.Migration.Models.Administrator;
using DigitalBank.Migration.Models.AdministratorPermission;
using DigitalBank.Migration.Models.Customer;
using DigitalBank.Migration.Models.CustomerPermission;
using DigitalBank.Migration.Models.Permission.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigitalBank.Migration.Models.Permission
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
