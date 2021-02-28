using System.Collections.Generic;

namespace DecisionSystems.DataPrediction.Predictor
{
    public class ConstantValuePredictor : IDataPredictor
    {
        private readonly double predictedValue;

        public ConstantValuePredictor(double predictedValue)
        {
            this.predictedValue = predictedValue;
        }

        public IDataPredictionModel Train(IReadOnlyList<DataPoint> data)
        {
            return new ConstantValuePredictionModel(predictedValue);
        }
    }
    public class ConstantValuePredictionModel: IDataPredictionModel
    {
        private readonly double predictedValue;
        public ConstantValuePredictionModel(double predictedValue)
        {
            this.predictedValue = predictedValue;
        }
        public double Test(double independentValuev/*Unabhängiger wert ==>gemessener Wert!*/)
        {
            return predictedValue;
        }
    }
}