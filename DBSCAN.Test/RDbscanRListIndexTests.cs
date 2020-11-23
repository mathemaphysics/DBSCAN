using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace DBSCAN.Test
{
	public class RDbscanRListIndexTests
	{
		public readonly ITestOutputHelper output;

		public RDbscanRListIndexTests(ITestOutputHelper output)
		{
			this.output = output;
		}

		[Fact]
		public void BorderTest1()
		{
			var clusters =
				RDBSCAN.CalculateClusters(
					RDbscanTestData.Borders,
					1.0,
					4);

			output.WriteLine($"Output: {clusters.Clusters.Count}");

			//Assert.Equal(2, clusters.Clusters.Count);
			//Assert.Equal(1, clusters.UnclusteredObjects.Count);
			//Assert.Equal(DbscanTestData.Borders[0], clusters.UnclusteredObjects[0]);

			//Assert.Equal(4, clusters.Clusters[0].Objects.Count);
			//Assert.Equal(4, clusters.Clusters[1].Objects.Count);
		}
	}
}
