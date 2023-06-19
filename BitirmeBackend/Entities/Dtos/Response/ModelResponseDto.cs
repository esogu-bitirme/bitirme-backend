using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Response
{
	public class ModelResponseDto
	{
		[ColumnName("softmax2")]
		public float[] Predictions { get; set; }
	}
}
