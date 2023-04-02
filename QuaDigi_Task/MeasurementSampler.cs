namespace QuaDigi_Task
{
    public class MeasurementSampler : IMeasurementSampler
    {
        public TimeSpan Interval { get; set; } = TimeSpan.FromMinutes(5);

        public Dictionary<MeasurementType, List<Measurement>> Sample(
            DateTime startOfSampling, List<Measurement> unsampledMeasurements)
        {
            if (unsampledMeasurements == null)
            {
                throw new ArgumentException("Argument is null", nameof(unsampledMeasurements));
            }

            var sampledMeasurements = new Dictionary<MeasurementType, List<Measurement>>();

            foreach (var t in Enum.GetValues<MeasurementType>())
            {
                sampledMeasurements.Add(t,
                    SampleByType(startOfSampling, unsampledMeasurements, t, Interval).ToList());
            }

            return sampledMeasurements;
        }


        public IEnumerable<Measurement> SampleByType(
            DateTime startOfSampling,
            IEnumerable<Measurement> unsampledMeasurements,
            MeasurementType type,             
            TimeSpan interval)
        {
            if (unsampledMeasurements == null)
            {
                throw new ArgumentException("Argument is null", nameof(unsampledMeasurements));
            }

            var measurements = unsampledMeasurements.Where(m => m.Type == type)
                                                    .OrderBy(m => m.MeasurementTime)
                                                    .SkipWhile(m => m.MeasurementTime < startOfSampling)
                                                    .DistinctBy(m => m.MeasurementTime)
                                                    .ToList();
            while (measurements.Any())
            {
                DateTime measureTime = measurements.First().MeasurementTime;
                DateTime borderTime = measureTime.Ceiling(interval);

                DateTime matchTime = measureTime.Add(interval);

                Measurement? lastInInterval = measurements.Where(m => m.MeasurementTime >= measureTime
                                                                   && m.MeasurementTime <= borderTime)
                                                          .MinBy(m => matchTime - m.MeasurementTime);

                measurements.RemoveRange(0, measurements.TakeWhile(m => m != lastInInterval)
                                                        .Count() + 1);              

                yield return new Measurement(borderTime, lastInInterval!.MeasurementValue, type);
            }
        }
    }
}
