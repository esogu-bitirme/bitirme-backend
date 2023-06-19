using Business.Abstract;
using Entities.Dtos.Request;
using Entities.Dtos.Response;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Concrete
{
	public class ModelService:IModelService
	{
		private readonly MLContext _mlContext;
		private readonly PredictionEngine<ModelRequestDto, ModelResponseDto> _predictionEngine;

		public ModelService()
		{
			_mlContext = new MLContext();

			string baseDirectory = Directory.GetCurrentDirectory();
			string modelPath = Path.Combine(baseDirectory, "Model", "SavedModel", "saved_model.pb");

			// TensorFlow yükleyicisini kullanarak modeli yükleyin
			var pipeline = _mlContext.Model.LoadTensorFlowModel("./Model/SavedModel/saved_model.pb")
				.ScoreTensorFlowModel(outputColumnNames: new[] { "softmax2" },
									  inputColumnNames: new[] { "dense_input" },
									  addBatchDimensionInput: true);
			var model = pipeline.Fit(_mlContext.Data.LoadFromEnumerable(new List<ModelRequestDto>()));
			_predictionEngine = _mlContext.Model.CreatePredictionEngine<ModelRequestDto, ModelResponseDto>(model);
		}

		public ModelResponseDto Predict(ModelRequestDto input)
		{
			return _predictionEngine.Predict(input);
		}

	}
}
