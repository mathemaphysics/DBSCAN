using System;

namespace DBSCAN
{
	public class RPointInfo<T> : IRPointData where T: IRPointData
	{
		public RPointInfo(T item) => this.Item = item;

		public T Item { get; }
		public Cluster<T> Cluster { get; set; }
		public bool Visited { get; set; }

		public ref readonly RPoint Point => ref Item.Point;
	}
}
