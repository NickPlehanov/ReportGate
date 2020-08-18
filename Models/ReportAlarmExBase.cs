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
        private string _new_andromeda_alarm { get; set; }
        public string new_andromeda_alarm {
            get => _new_andromeda_alarm;
            set {
                using (AndromedaContext andromedaContext = new AndromedaContext()) {
                    Guid guid = Guid.Parse(value);
                    List<Andromeda> andromedas = andromedaContext.Andromeda.Where(x => x.New_andromedaId == guid).ToList<Andromeda>();
                    _new_andromeda_alarm = "№ " + andromedas[0].New_number.ToString() + "(" + andromedas[0].New_name.Replace('\"','\'') + ") " + andromedas[0].New_address;
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
    }
}