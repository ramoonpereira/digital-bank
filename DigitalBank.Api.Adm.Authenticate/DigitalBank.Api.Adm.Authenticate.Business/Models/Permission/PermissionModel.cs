using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalBank.Api.Adm.Authenticate.Business.Models.Permission
{
    [Table("administrator_permissions")]
    public class PermissionModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("permissions")]
        public string Permissions { get; set; }

        [Column("created_at")]
        public DateTime CreatedDate { get; set; }

        [Column("administrator_id")]
        public int AdministratorId{ get; set; }
    }
}
