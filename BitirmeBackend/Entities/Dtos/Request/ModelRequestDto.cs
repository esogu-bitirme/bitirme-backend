using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Request
{
	public class ModelRequestDto
	{
		[VectorType(4)]
		public float[] Features { get; set; }
	}
}
