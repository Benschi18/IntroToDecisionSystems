using System;
using System.Collections.Generic;
using System.Linq;

namespace DecisionSystems.DataPrediction.Predictor
{
    public class RandomValuePredictor : IDataPredictor
    {
        public RandomValuePredictor()
        {
        }

        public IDataPredictionModel Train(IReadOnlyList<DataPoint> data)
        {
            Random random = new Random(777);

            return new RandomDataPredictionModel(Min(data),Max(data));
        }

        private double Min(IReadOnlyList<DataPoint> data)
        {
            return data.Min(DataPoint => DataPoint.DependentValue);
        }

        private double Max(IReadOnlyList<DataPoint> data)
        {
            return data.Max(DataPoint => DataPoint.DependentValue);
        }

        private class RandomDataPredictionModel : IDataPredictionModel
        {
            private int v;
            private Random generator = new Random(777);
            public RandomDataPredictionModel(double minValue,double maxValue)
            {
            }

            public double Text(double independentValue)
            {
                return kp
            }
        }
    }
}