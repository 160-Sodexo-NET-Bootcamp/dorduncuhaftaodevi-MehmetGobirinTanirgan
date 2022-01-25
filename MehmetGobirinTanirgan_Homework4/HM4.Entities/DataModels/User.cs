using HM4.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace HM4.Entities.DataModels
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime CreatedDate { get; set; }
        public Status Status { get; set; }
    }
}
