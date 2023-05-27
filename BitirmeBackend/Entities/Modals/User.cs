﻿using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Modals
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(30)]
        public string Username { get; set; }
        public string Password { get; set; }
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Column("UserType")]
        public string UserTypeString 
        { 
            get { return UserType.ToString(); }
            private set { UserType = value.ParseEnum<UserType>(); } 
        }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        [NotMapped]
        public UserType UserType { get; set; }


    }
}
