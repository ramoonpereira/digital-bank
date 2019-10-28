using DigitalBank.Migrations.Models.Administrator;
using DigitalBank.Migrations.Models.Permission;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Migrations.Models.AdministratorPermission
{
    [Table("administrator_permissions")]
    public class AdministratorPermissionModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("permissions")]
        public string Permissions { get; set; }

        [Column("created_at")]
        public DateTime CreatedDate { get; set; }

        [Column("administrator_id")]
        public int AdministratorId { get; set; }

        [Column("permission_id")]
        public int PermissionId { get; set; }

        [ForeignKey("AdministratorId")]
        public virtual AdministratorModel Administrator { get; set; }

        [ForeignKey("PermissionId")]
        public virtual PermissionModel Permission { get; set; }
    }
}
