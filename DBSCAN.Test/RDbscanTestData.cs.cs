using System;
using System.Collections.Generic;
using System.Text;

namespace DBSCAN.Test
{
	class RDbscanTestData
	{
		public class _RPoint : IRPointData
		{
			private readonly RPoint _point;

			public _RPoint(double X, double Y, double W, double H) =>
				_point = new RPoint(X, Y, W, H);

			public ref readonly RPoint Point => ref _point;
		}

		public static IList<_RPoint> Borders = new List<_RPoint>
		{
			new _RPoint(X: 0, Y: 0, W: 2.5, H: 2.5),
			new _RPoint(X: -1.8, Y: 0, W: 2.5, H: 2.5),
			new _RPoint(X: -2.3, Y: 0, W: 2.5, H: 2.5),
			new _RPoint(X: -2.3, Y: 0.5, W: 2.5, H: 2.5),
			new _RPoint(X: -2.3, Y: -0.5, W: 2.5, H: 2.5),
			new _RPoint(X: 1.8, Y: 0, W: 2.5, H: 2.5),
			new _RPoint(X: 2.3, Y: 0, W: 2.5, H: 2.5),
			new _RPoint(X: 2.3, Y: 0.5, W: 2.5, H: 2.5),
			new _RPoint(X: 2.3, Y: -0.5, W: 2.5, H: 2.5),
		};
	}
}
