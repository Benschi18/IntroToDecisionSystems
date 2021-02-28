using System.Collections.Generic;
using static DecisionSystems.Pages.DataPredictionPage;

namespace DecisionSystems.DataPrediction.Predictor
{
    public interface IDataPredictor
    {
        IDataPredictionModel Train(IReadOnlyList<DataPoint> data);
    }
}