using Entities.Dtos.Request;
using Entities.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IModelService
	{
		ModelResponseDto Predict(ModelRequestDto input);
	}
}
