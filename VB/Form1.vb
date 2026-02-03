Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler

Namespace AptTooltipDrag

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub schedulerControl1_AppointmentDrag(ByVal sender As Object, ByVal e As AppointmentDragEventArgs)
            If e.HitInterval.Start.TimeOfDay.Hours <= 9 Then
                toolTipController1.ShowHint("You cannot move appointment to this area")
                Call Application.DoEvents()
            Else
                toolTipController1.HideHint()
            End If
        End Sub

        Private Sub schedulerControl1_AppointmentDrop(ByVal sender As Object, ByVal e As AppointmentDragEventArgs)
            If e.HitInterval.Start.TimeOfDay.Hours <= 9 Then
                toolTipController1.ShowHint("Operation is cancelled")
                e.Allow = False
            End If
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim apt As Appointment = schedulerStorage1.CreateAppointment(AppointmentType.Normal)
            apt.Start = Date.Now.Date.AddHours(12)
            apt.Subject = "Sample Appointment"
            schedulerStorage1.Appointments.Add(apt)
            schedulerControl1.ActiveViewType = SchedulerViewType.Day
            schedulerControl1.Start = Date.Now.Date
            schedulerControl1.DayView.TopRowTime = New TimeSpan(8, 0, 0)
        End Sub
    End Class
End Namespace
