using System;
using System.Collections.Generic;
using System.Text;

namespace DBSCAN
{
	public interface IRSpatialIndex<out T>
	{
		IReadOnlyList<T> Search();
		IReadOnlyList<T> Search(in RPoint p, double epsilon);
	}
}
