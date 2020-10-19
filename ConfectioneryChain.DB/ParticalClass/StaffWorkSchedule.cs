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
            var general = new StaffWorkSchedule();
            general.IDStaffWorkSchedule = -1;
            general.ConfectioneryID = -1;
            general.EmployeeID = -1;
            general.WorkDay = DateTime.Now;
            general.TimeBeginWork = new TimeSpan(8, 0, 0);
            general.TimeEndWork = new TimeSpan(23, 0, 0);
            general.TimeBeginLunch = new TimeSpan(13, 0, 0);
            general.TimeEndLunch = new TimeSpan(13, 45, 0);
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
