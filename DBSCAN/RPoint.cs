using System;
using System.Collections.Generic;
using System.Text;

namespace DBSCAN
{
	public readonly struct RPoint
	{
		public double X { get; }
		public double Y { get; }
		public double W { get; }
		public double H { get; }

		public RPoint(double X, double Y, double W, double H)
		{
			this.X = X;
			this.Y = Y;
			this.W = W;
			this.H = H;
		}
	}
}
