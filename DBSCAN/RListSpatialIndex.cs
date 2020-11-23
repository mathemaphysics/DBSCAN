using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBSCAN
{
	public class RListSpatialIndex<T> : IRSpatialIndex<T> where T : IRPointData
	{
		public delegate double DistanceFunction(in RPoint a, in RPoint b);

		private IReadOnlyList<T> list;
		private DistanceFunction distanceFunction;

		public RListSpatialIndex(IEnumerable<T> data)
			: this(data, REuclideanDistance) { }

		public RListSpatialIndex(IEnumerable<T> data, DistanceFunction distanceFunction)
		{
			this.list = data.ToList();
			this.distanceFunction = distanceFunction;
		}

		public static double REuclideanDistance(in RPoint a, in RPoint b)
		{
			var xDiam = (b.W + a.W) / 2.0;
			var yDiam = (b.H + a.H) / 2.0;
			var xDist = Math.Max(Math.Abs(b.X - a.X) - xDiam, 0.0);
			var yDist = Math.Max(Math.Abs(b.Y - a.Y) - yDiam, 0.0);
			return Math.Sqrt(xDist * xDist + yDist * yDist);
		}

		public IReadOnlyList<T> Search() => list;
		public IReadOnlyList<T> Search(in RPoint p, double epsilon)
		{
			var l = new List<T>();
			foreach (var q in list)
				if (distanceFunction(p, q.Point) < epsilon)
					l.Add(q);
			return l;
		}
	}
}
