namespace QuaDigi_Task
{
    public static class DateExtensions
    {
        public static DateTime Ceiling(this DateTime dateTime, TimeSpan interval)
        {
            double overflow = dateTime.TimeOfDay.TotalSeconds % interval.TotalSeconds;

            return overflow == 0 ? dateTime : dateTime.AddSeconds(interval.TotalSeconds - overflow);
        }
    }
}
