using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class NotificationManager : MonoBehaviour
{
    [SerializeField] private int _hoursToNotif;
    private void Start()
    {
        var notificationChannel = new AndroidNotificationChannel()
        {
            Id = "reminder_notif",
            Name = "Reminder Notification",
            Description = "Channel for reminders notification",
            Importance = Importance.High
        };

        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);

        var notif = new AndroidNotification();
        notif.Title = "Only Road";
        notif.Text = "¡Hay autos que esquivar!";
        notif.SmallIcon = "icon_remindersmall";
        notif.LargeIcon = "icon_reminderbig";
        notif.FireTime = System.DateTime.Now.AddHours(_hoursToNotif);

        AndroidNotificationCenter.SendNotification(notif, "reminder_notif");
    }
}
