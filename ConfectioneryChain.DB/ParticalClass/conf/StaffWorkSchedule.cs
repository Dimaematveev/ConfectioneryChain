using ConfectioneryChain.DB.Inheritance;
using System;

namespace ConfectioneryChain.DB
{
    public partial class StaffWorkSchedule : General
    {
        public override string ToString()
        {
            return $"[{IDStaffWorkSchedule}]";
        }
        public override General CreateNew()
        {
            var general = new StaffWorkSchedule
            {
                IDStaffWorkSchedule = -1,
                ConfectioneryID = -1,
                EmployeeID = -1,
                WorkDay = DateTime.Now,
                TimeBeginWork = new TimeSpan(8, 0, 0),
                TimeEndWork = new TimeSpan(23, 0, 0),
                TimeBeginLunch = new TimeSpan(13, 0, 0),
                TimeEndLunch = new TimeSpan(13, 45, 0)
            };
            return general;
        }

        public override void Fill(General copy)
        {
            if (copy is StaffWorkSchedule general)
            {
                ConfectioneryID = general.ConfectioneryID;
                EmployeeID = general.EmployeeID;
                WorkDay = general.WorkDay;
                TimeBeginWork = general.TimeBeginWork;
                TimeEndWork = general.TimeEndWork;
                TimeBeginLunch = general.TimeBeginLunch;
                TimeEndLunch = general.TimeEndLunch;
            }


        }

        public override void AllFill(General copy)
        {
            if (copy is StaffWorkSchedule general)
            {
                Fill(general);
                IDStaffWorkSchedule = general.IDStaffWorkSchedule;
            }


        }
    }
}
