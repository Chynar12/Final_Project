using System;
using System.Timers;

public class VocabularyReminder
{
    private System.Timers.Timer reminderTimer;

    public void StartReminder(DateTime reminderTime)
    {
        // Calculate the time until the first reminder
        double interval = (reminderTime - DateTime.Now).TotalMilliseconds;

        if (interval < 0)
        {
            // If the calculated interval is negative, set it for the next day
            interval = (reminderTime.AddDays(1) - DateTime.Now).TotalMilliseconds;
        }

        // Create and start the timer
        reminderTimer = new System.Timers.Timer(interval);
        reminderTimer.Elapsed += OnReminderTimerElapsed;
        reminderTimer.AutoReset = false; // Set to false for a one-time reminder
        reminderTimer.Start();

        Console.WriteLine("Vocabulary reminder scheduled at: " + reminderTime);
    }

    private void OnReminderTimerElapsed(object sender, ElapsedEventArgs e)
    {
        // This method is called when the timer elapses
        Console.WriteLine("Time to practice vocabulary!");

        // Additional logic to send a notification or perform any other action

        // Stop the timer (since AutoReset is set to false, it won't restart)
        reminderTimer.Stop();
    }
}


