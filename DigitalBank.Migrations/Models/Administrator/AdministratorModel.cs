﻿using DigitalBank.Migrations.Models.AdministratorPermission;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Migrations.Models.Administrator
{
    [Table("administrators")]
    public class AdministratorModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("phone")]
        public long Phone { get; set; }

        [Column("birth_date")]
        public DateTime BirthDate { get; set; }

        [Column("document")]
        public long Document { get; set; }

        [Column("status")]
        public bool Status { get; set; }

        [Column("created_at")]
        public DateTime CreatedDate { get; set; }

        [NotMapped]
        public virtual ICollection<AdministratorPermissionModel> AdministratorPermissions { get; set; }
    }
}
