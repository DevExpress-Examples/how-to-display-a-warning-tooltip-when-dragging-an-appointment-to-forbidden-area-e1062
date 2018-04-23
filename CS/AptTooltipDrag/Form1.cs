using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;

namespace AptTooltipDrag {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }


        private void schedulerControl1_AppointmentDrag(object sender, DevExpress.XtraScheduler.AppointmentDragEventArgs e) {
            if (e.HitInterval.Start.TimeOfDay.Hours <= 9) {
                this.toolTipController1.ShowHint("You cannot move appointment to this area");
                Application.DoEvents();
                e.Handled = true;
            } else
                this.toolTipController1.HideHint();
        }

        private void schedulerControl1_AppointmentDrop(object sender, DevExpress.XtraScheduler.AppointmentDragEventArgs e) {
            if (e.HitInterval.Start.TimeOfDay.Hours <= 9) {
                this.toolTipController1.ShowHint("Operation is cancelled");
                e.Handled = true;
                e.Allow = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            Appointment apt = this.schedulerStorage1.CreateAppointment(AppointmentType.Normal);
            apt.Start = DateTime.Now.Date.AddHours(12);
            apt.Subject = "Sample Appointment";
            this.schedulerStorage1.Appointments.Add(apt);
            this.schedulerControl1.ActiveViewType = SchedulerViewType.Day;
            this.schedulerControl1.Start = DateTime.Now.Date;
            this.schedulerControl1.DayView.TopRowTime = new TimeSpan(8, 0, 0);
        }
    }
}