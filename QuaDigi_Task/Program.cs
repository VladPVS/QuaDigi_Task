namespace QuaDigi_Task
{
    internal partial class Program
    {
        private static List<Measurement> Measurements => new()
        {
            new (DateTime.Parse("2017-01-03T10:04:45"), 35.79, MeasurementType.TEMP),
            new (DateTime.Parse("2017-01-03T10:01:18"), 98.78, MeasurementType.SPO2),
            new (DateTime.Parse("2017-01-03T10:09:07"), 35.01, MeasurementType.TEMP),
            new (DateTime.Parse("2017-01-03T10:03:34"), 96.49, MeasurementType.SPO2),

            new (DateTime.Parse("2017-01-03T10:02:01"), 35.82, MeasurementType.TEMP),
            new (DateTime.Parse("2017-01-03T10:05:00"), 97.17, MeasurementType.SPO2),
            new (DateTime.Parse("2017-01-03T10:05:01"), 95.08, MeasurementType.SPO2),
        };


        static void Main(string[] args)
        {
            IMeasurementSampler sampler = new MeasurementSampler();
            DateTime startDate = DateTime.Parse("2017-01-03T10:00:00");

            Console.WriteLine("INPUT:");
            Measurements.ForEach(Console.WriteLine);

            Console.WriteLine("\nOUTPUT:");
            foreach (var m in sampler.Sample(startDate, Measurements))
            {
                m.Value.ForEach(Console.WriteLine);
            }

            Console.ReadKey(true);
        }
    }
}