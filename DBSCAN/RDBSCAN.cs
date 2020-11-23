﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBSCAN
{
	public static class RDBSCAN
	{
		public static ClusterSet<T> CalculateClusters<T>(
			IList<T> data,
			double epsilon,
			int minimumPointsPerCluster)
			where T : IRPointData
		{
			var pointInfos = data
				.Select(p => new RPointInfo<T>(p))
				.ToList();

			return CalculateClusters(
				new RListSpatialIndex<RPointInfo<T>>(pointInfos),
				epsilon,
				minimumPointsPerCluster);
		}

		public static ClusterSet<T> CalculateClusters<T>(
			IRSpatialIndex<RPointInfo<T>> index,
			double epsilon,
			int minimumPointsPerCluster)
			where T : IRPointData
		{
			var points = index.Search().ToList();

			var clusters = new List<Cluster<T>>();

			foreach (var p in points)
			{
				if (p.Visited) continue;

				p.Visited = true;
				var candidates = index.Search(p.Point, epsilon);

				if (candidates.Count >= minimumPointsPerCluster)
				{
					clusters.Add(
						BuildCluster(
							index,
							p,
							candidates,
							epsilon,
							minimumPointsPerCluster));
				}
			}

			return new ClusterSet<T>
			{
				Clusters = clusters,
				UnclusteredObjects = points
					.Where(p => p.Cluster == null)
					.Select(p => p.Item)
					.ToList(),
			};
		}

		private static Cluster<T> BuildCluster<T>(IRSpatialIndex<RPointInfo<T>> index, RPointInfo<T> point, IReadOnlyList<RPointInfo<T>> neighborhood, double epsilon, int minimumPointsPerCluster)
			where T : IRPointData
		{
			var points = new List<T>() { point.Item };
			var cluster = new Cluster<T>() { Objects = points };
			point.Cluster = cluster;

			var queue = new Queue<RPointInfo<T>>(neighborhood);
			while (queue.Any())
			{
				var newPoint = queue.Dequeue();
				if (!newPoint.Visited)
				{
					newPoint.Visited = true;
					var newNeighbors = index.Search(newPoint.Point, epsilon);
					if (newNeighbors.Count >= minimumPointsPerCluster)
						foreach (var p in newNeighbors)
							queue.Enqueue(p);
				}

				if (newPoint.Cluster == null)
				{
					newPoint.Cluster = cluster;
					points.Add(newPoint.Item);
				}
			}

			return cluster;
		}

	}
}
