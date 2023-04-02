using System.Globalization;

namespace QuaDigi_Task
{
    public class Measurement
    {
        private DateTime measurementTime;

        private double measurementValue;

        private MeasurementType type;

        public DateTime MeasurementTime { get => measurementTime; }
        public double MeasurementValue { get => measurementValue; }
        public MeasurementType Type { get => type; }

        public Measurement(DateTime measurementTime,
            double measurementValue,
            MeasurementType type)
        {
            this.measurementTime = measurementTime;
            this.measurementValue = measurementValue;
            this.type = type;
        }


        public override string ToString() 
        {
            return $"{{{measurementTime:s}, {type}, " +
                $"{measurementValue.ToString("0.00", NumberFormatInfo.InvariantInfo)}}}";
        }
    }
}