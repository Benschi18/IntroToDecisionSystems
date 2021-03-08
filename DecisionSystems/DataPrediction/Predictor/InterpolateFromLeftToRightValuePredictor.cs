using System.Collections.Generic;

namespace DecisionSystems.DataPrediction.Predictor
{
    public class InterpolateFromLeftToRightValuePredictor : IDataPredictor
    {
        public InterpolateFromLeftToRightValuePredictor()
        {
        }

        public IDataPredictionModel Train(IReadOnlyList<DataPoint> data)
        {
            var left = data.BestBy(dataPoint => dataPoint.IndependentValue, (a, b) => a < b);
            var right = data.BestBy(dataPoint => dataPoint.IndependentValue, (a, b) => a > b);
            var dx = right.IndependentValue - left.IndependentValue;
            var dy = right.DependentValue - left.DependentValue;
            var k = dy / dx;
            var d = left.DependentValue - k * left.IndependentValue;
            //return new InterpolateFromLeftToRightPredictionModel(MinX(data), MaxX(data),MinY(data),MaxY(data));
            return new LinearPredictionModel(k, d);
        }

        //private double MinX(IReadOnlyList<DataPoint> data)
        //{
        //    return data.Min(DataPoint => DataPoint.IndependentValue);
        //}

        //private double MaxX(IReadOnlyList<DataPoint> data)
        //{
        //    return data.Max(DataPoint => DataPoint.IndependentValue);
        //}
        //private double MinY(IReadOnlyList<DataPoint> data)
        //{
        //    return data.Min(DataPoint => DataPoint.DependentValue);
        //}

        //private double MaxY(IReadOnlyList<DataPoint> data)
        //{
        //    return data.Max(DataPoint => DataPoint.DependentValue);
        //}


        private class LinearPredictionModel : IDataPredictionModel
        {
            private readonly double k;
            private readonly double d;

            public LinearPredictionModel(double k, double d)
            {
                this.k = k;
                this.d = d;
            }

            public double Test(double independentValue)
            {
                return k * independentValue + d;
            }
        }
    }
}