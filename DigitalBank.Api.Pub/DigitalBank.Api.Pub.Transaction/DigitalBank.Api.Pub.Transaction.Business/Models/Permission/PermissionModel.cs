using DigitalBank.Api.Pub.Transaction.Business.Models.Permission.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigitalBank.Api.Pub.Transaction.Business.Models.Permission
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
    }
}
