Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler

Namespace AptTooltipDrag
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub


		Private Sub schedulerControl1_AppointmentDrag(ByVal sender As Object, ByVal e As DevExpress.XtraScheduler.AppointmentDragEventArgs) Handles schedulerControl1.AppointmentDrag
			If e.HitInterval.Start.TimeOfDay.Hours <= 9 Then
				Me.toolTipController1.ShowHint("You cannot move appointment to this area")
				Application.DoEvents()
				e.Handled = True
			Else
				Me.toolTipController1.HideHint()
			End If
		End Sub

		Private Sub schedulerControl1_AppointmentDrop(ByVal sender As Object, ByVal e As DevExpress.XtraScheduler.AppointmentDragEventArgs) Handles schedulerControl1.AppointmentDrop
			If e.HitInterval.Start.TimeOfDay.Hours <= 9 Then
				Me.toolTipController1.ShowHint("Operation is cancelled")
				e.Handled = True
				e.Allow = False
			End If
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Dim apt As Appointment = Me.schedulerStorage1.CreateAppointment(AppointmentType.Normal)
			apt.Start = DateTime.Now.Date.AddHours(12)
			apt.Subject = "Sample Appointment"
			Me.schedulerStorage1.Appointments.Add(apt)
			Me.schedulerControl1.ActiveViewType = SchedulerViewType.Day
			Me.schedulerControl1.Start = DateTime.Now.Date
			Me.schedulerControl1.DayView.TopRowTime = New TimeSpan(8, 0, 0)
		End Sub
	End Class
End Namespace