namespace QuaDigi_Task
{
    public interface IMeasurementSampler
    {
        TimeSpan Interval { get; set; }

        Dictionary<MeasurementType, List<Measurement>> Sample(DateTime startOfSampling, List<Measurement> unsampledMeasurements);
        
        IEnumerable<Measurement> SampleByType(DateTime startOfSampling, IEnumerable<Measurement> unsampledMeasurements, MeasurementType type, TimeSpan interval);
    }
}