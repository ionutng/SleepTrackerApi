namespace SleepTrackerApi.Models;

public class SleepRecord
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly FallAsleepTime { get; set; }
    public TimeOnly WakeUpTime { get; set; }
    public TimeSpan SleepDuration
    {
        get
        {
            if (WakeUpTime > FallAsleepTime)
            {
                return WakeUpTime - FallAsleepTime;
            }
            else
            {
                return (WakeUpTime.AddHours(24) - FallAsleepTime);
            }
        }
    }
}
