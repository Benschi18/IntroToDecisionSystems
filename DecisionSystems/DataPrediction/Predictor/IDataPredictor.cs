using Microsoft.ML;
using Microsoft.ML.Data;
using System.Collections.Generic;
using System.Linq;

namespace DecisionSystems.DataPrediction.Predictor
{
    public interface IDataPredictor
    {
        IDataPredictionModel Train(IReadOnlyList<DataPoint> data);
    }

    public class GradientDescentPredictor : IDataPredictor
    {
        public IDataPredictionModel Train(IReadOnlyList<DataPoint> data)
        {
            var mlContext = new MLContext(seed: 0);

            var dataPoints = data.Select(MLNetDataPoint.FromDomain);
            var dataView = mlContext.Data.LoadFromEnumerable(dataPoints);
            var pipeline = mlContext.Transforms.NormalizeMinMax(new[] { new InputOutputColumnPair("Features")})
                .Append(mlContext.Regression.Trainers.OnlineGradientDescent(learningRate: 1));
            var model = pipeline.Fit(dataView); //Training

            var predictionFunction= mlContext.Model.CreatePredictionEngine<MLNetDataPoint, MLNetDataPointPrediction>(model);
            return new MlNetDataPredictionModel(predictionFunction);
        }

        private class MLNetDataPoint    // ML.Net works with float-values only.
        {
            [VectorType(1)] // number of features is 1

            public float[] features; // independent values
            public float label; // dependent value

            public static MLNetDataPoint FromDomain(DataPoint dataPoint)
            {
                return new MLNetDataPoint
                {
                    features = new[]
                    {
                        (float)dataPoint.IndependentValue
                    },
                    label = (float)dataPoint.DependentValue
                };
            }
        }
        private class MLNetDataPointPrediction
        {
            public float score; //predicted value
        }

        private class MlNetDataPredictionModel : IDataPredictionModel
        {
            private PredictionEngine<MLNetDataPoint, MLNetDataPointPrediction> predictionFunction;

            public MlNetDataPredictionModel(PredictionEngine<MLNetDataPoint, MLNetDataPointPrediction> predictionFunction)
            {
                this.predictionFunction = predictionFunction;
            }

            public double Test(double independentValue)
            {
                var prediction = predictionFunction.Predict(new MLNetDataPoint {features=new[] { (float)independentValue} });
                return prediction.score;
            }
        }
    }
}