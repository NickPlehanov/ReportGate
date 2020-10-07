using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReportGate.Models {
    public class ReportAlarmExBase {
        public Guid? new_alarmid { get; set; }
        public string new_name { get; set; }
        public bool? new_onc { get; set; }
        public bool? new_tpc { get; set; }

        private int? _new_group { get; set; }
        public int? new_group {
            get => _new_group;
            set {
                _new_group = value + 69;
            }
        }

        private DateTime? _new_arrival { get; set; }
        public DateTime? new_arrival {
            get => _new_arrival;
            set {
                if (value.HasValue)
                    _new_arrival = DateTime.Parse(value.Value.ToString()).AddHours(5);
            }
        }

        private DateTime? _new_cancel { get; set; }
        public DateTime? new_cancel {
            get => _new_cancel;
            set {
                if (value.HasValue)
                    _new_cancel = DateTime.Parse(value.Value.ToString()).AddHours(5);
            }
        }
        private DateTime? _new_departure { get; set; }
        public DateTime? new_departure {
            get => _new_departure;
            set {
                if (value.HasValue)
                    _new_departure = DateTime.Parse(value.Value.ToString()).AddHours(5);
            }
        }

        private Guid? _new_andromeda_alarm { get; set; }
        public Guid? new_andromeda_alarm {
            get => _new_andromeda_alarm;
            set {
                _new_andromeda_alarm = value;
            }
        }

        private string _new_number { get; set; }
        public string new_number {
            get => _new_number;
            set {
                using (AndromedaContext andromedaContext = new AndromedaContext()) {
                    Guid guid = Guid.Parse(new_andromeda_alarm.ToString());
                    _new_number = andromedaContext.Andromeda.FirstOrDefault(x => x.New_andromedaId == guid).New_number.ToString().Replace('\"', '\'');
                }
            }
        }

        private string _new_objname { get; set; }
        public string new_objname {
            get => _new_objname;
            set {
                using (AndromedaContext andromedaContext = new AndromedaContext()) {
                    Guid guid = Guid.Parse(new_andromeda_alarm.ToString());
                    _new_objname = andromedaContext.Andromeda.FirstOrDefault(x => x.New_andromedaId == guid).New_name.Replace('\"', '\'');
                }
            }
        }

        private string _new_address { get; set; }
        public string new_address {
            get => _new_address;
            set {
                using (AndromedaContext andromedaContext = new AndromedaContext()) {
                    Guid guid = Guid.Parse(new_andromeda_alarm.ToString());
                    _new_address = andromedaContext.Andromeda.FirstOrDefault(x => x.New_andromedaId == guid).New_address.Replace('\"', '\'');
                }
            }
        }

        public bool? new_owner { get; set; }
        public bool? new_police { get; set; }
        public bool? new_order { get; set; }
        public bool? new_act { get; set; }

        private DateTime? _new_alarm_dt { get; set; }
        public DateTime? new_alarm_dt {
            get => _new_alarm_dt;
            set {
                if (value.HasValue)
                    _new_alarm_dt = DateTime.Parse(value.Value.ToString()).AddHours(5);
            }
        }

        public string new_zone { get; set; }
        public bool? new_ps { get; set; }
        public string delta { get; set; }
        public string reason { get; set; }
    }
}