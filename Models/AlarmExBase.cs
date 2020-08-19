using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ReportGate.Models {
    [Table("New_alarmExtensionBase")]
    public class AlarmExBase {
        [Key]
        public Guid? new_alarmid { get; set; }
        public string new_name { get; set; }
        public bool? new_onc { get; set; }
        public bool? new_tpc { get; set; }
        public int? new_group { get; set; }
        public DateTime? new_arrival { get; set; }
        public DateTime? new_cancel { get; set; }
        public DateTime? new_departure { get; set; }
        public Guid? new_andromeda_alarm { get; set; }
        public bool? new_owner { get; set; }
        public bool? new_police { get; set; }
        public bool? new_order { get; set; }
        public bool? new_act { get; set; }
        public DateTime? new_alarm_dt { get; set; }
        public string new_zone { get; set; }
        public bool? new_ps { get; set; }
        [NotMapped]
        public string new_number { get; set; }
        [NotMapped]
        public string new_objname { get; set; }
        [NotMapped]
        public string new_address { get; set; }
    }
    public class AlarmExBaseContext : DbContext {
        public AlarmExBaseContext() : base("VityazMSCRMEntity") { }
        public DbSet<AlarmExBase> AlarmExBase { get; set; }
    }
}