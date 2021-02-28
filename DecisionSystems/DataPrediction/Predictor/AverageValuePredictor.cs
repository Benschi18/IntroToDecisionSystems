using System.Collections.Generic;
using System.Linq;

namespace DecisionSystems.DataPrediction.Predictor
{
    public class AverageValuePredictor : IDataPredictor
    {
        public AverageValuePredictor()
        {

        }

        public IDataPredictionModel Train(IReadOnlyList<DataPoint> data)
        {
            //int ctr = 0;
            var average = data.Average(dataPoint=> dataPoint.DependentValue);
            //foreach (var item in data)
            //{
            //    average += item.DependentValue;
            //    ctr++;
            //}
            return new ConstantValuePredictionModel(average);
        }
    }
}