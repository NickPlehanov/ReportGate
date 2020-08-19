using Newtonsoft.Json;
using ReportGate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReportGate.Controllers {
    public class ReportController : ApiController {
        [HttpGet]
        public string GetReport(string late, string date) {
            double _late = 0;
            if (!double.TryParse(late.ToString(), out _))
                _late = 0;
            else
                _late = double.Parse(late);
            if (DateTime.TryParse(date, out _)) {
                using (AlarmExBaseContext alarmExBaseContext = new AlarmExBaseContext()) {
                    int Year = DateTime.Parse(date).Year;
                    int Month = DateTime.Parse(date).Month;
                    int Day = DateTime.Parse(date).Day;
                    DateTime start = new DateTime(Year, Month, Day, 0, 0, 0).AddHours(-5);
                    //DateTime end = new DateTime(Year, Month, Day, 23, 59, 59);
                    DateTime end = new DateTime(Year, Month, Day, 3, 59, 59).AddHours(-5);
                    List<ReportAlarmExBase> aeb = new List<ReportAlarmExBase>();
                    var d = alarmExBaseContext.AlarmExBase.Where(x => x.new_alarm_dt != null && x.new_alarm_dt > start
                              && x.new_alarm_dt <= end);
                    foreach (AlarmExBase item in d) {
                        if (item.new_arrival.HasValue && item.new_alarm_dt.HasValue)
                            if ((item.new_arrival - item.new_alarm_dt).Value.TotalMinutes >= _late)
                                aeb.Add(new ReportAlarmExBase() {
                                    new_act = item.new_act,
                                    new_alarmid = item.new_alarmid,
                                    new_alarm_dt = item.new_alarm_dt,
                                    new_andromeda_alarm = item.new_andromeda_alarm,
                                    new_address=item.new_address,
                                    new_number=item.new_number,
                                    new_objname=item.new_objname,
                                    new_arrival = item.new_arrival,
                                    new_cancel = item.new_cancel,
                                    new_departure = item.new_departure,
                                    new_group = item.new_group,
                                    new_name = item.new_name,
                                    new_onc = item.new_onc,
                                    new_order = item.new_order,
                                    new_owner = item.new_owner,
                                    new_police = item.new_police,
                                    new_ps = item.new_ps,
                                    new_tpc = item.new_tpc,
                                    new_zone = item.new_zone
                                }); ;
                    }
                    return JsonConvert.SerializeObject(aeb);
                }
            }
            else
                return JsonConvert.SerializeObject("Введенное значение не является датой");
        }
    }
}
