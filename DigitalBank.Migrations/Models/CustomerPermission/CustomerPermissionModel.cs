using DigitalBank.Migrations.Models.Customer;
using DigitalBank.Migrations.Models.Permission;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Migrations.Models.CustomerPermission
{
    [Table("customer_permissions")]
    public class CustomerPermissionModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("permissions")]
        public string Permissions { get; set; }

        [Column("created_at")]
        public DateTime CreatedDate { get; set; }

        [Column("customer_id")]
        public int CustomerId { get; set; }

        [Column("permission_id")]
        public int PermissionId { get; set; }

        [ForeignKey("PermissionId")]
        public virtual PermissionModel Permission { get; set; }

        [ForeignKey("CustomerId")]
        public virtual CustomerModel Customer { get; set; }
    }
}
