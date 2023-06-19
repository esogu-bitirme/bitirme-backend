using Business.Abstract;
using Entities.Dtos.Request;
using Entities.Dtos.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.controllers
{
	[Route("api/model")]
	[ApiController]
	public class ModelController:ControllerBase
	{	
		private readonly IModelService _modelService;
		public ModelController(IModelService modelService) {
			_modelService = modelService;
		}

		[HttpPost]
		public ActionResult<ModelResponseDto> Predict()
		{
			var input = new ModelRequestDto
			{
				Features = new float[] { 0.5f, 0.3f, 0.2f, 0.1f } // Örnek veri olarak 4 elemanlı bir float dizisi
			};

			var prediction = _modelService.Predict(input);
			return prediction;
		}

	}
}
