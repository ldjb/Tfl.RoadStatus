using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using Tfl.RoadStatus.Common;
using Tfl.RoadStatus.Exceptions;

namespace Tfl.RoadStatus.Test
{
	[TestClass]
	public class ApiClientTests
	{
		[TestMethod]
		public async Task GetRoad_ValidRoad_ShouldReturnRoad()
		{
			// Arrange
			var mockHttpClient = new Mock<IHttpClientWrapper>();
			var jsonResponse = File.ReadAllText("TestData/A2.json");
			mockHttpClient.Setup(x => x.GetAsync(It.IsAny<string>()))
				.ReturnsAsync(new HttpResponseMessage
				{
					StatusCode = HttpStatusCode.OK,
					Content = new StringContent(jsonResponse)
				});
			var apiClient = new ApiClient(mockHttpClient.Object);

			// Act
			var road = await apiClient.GetRoad("appKey", "A2");

			// Assert
			Assert.AreEqual(road.DisplayName, "A2");
			Assert.AreEqual(road.StatusSeverity, "Good");
			Assert.AreEqual(road.StatusSeverityDescription, "No Exceptional Delays");
		}

		[TestMethod]
		public async Task GetRoad_InvalidRoad_ShouldThrowRoadNotFoundException()
		{
			// Arrange
			var mockHttpClient = new Mock<IHttpClientWrapper>();
			var jsonResponse = File.ReadAllText("TestData/A233.json");
			mockHttpClient.Setup(x => x.GetAsync(It.IsAny<string>()))
				.ReturnsAsync(new HttpResponseMessage
				{
					StatusCode = HttpStatusCode.NotFound,
					Content = new StringContent(jsonResponse)
				});
			var apiClient = new ApiClient(mockHttpClient.Object);

			// Act and Assert
			await Assert.ThrowsExceptionAsync<RoadNotFoundException>(async () =>
			{
				await apiClient.GetRoad("appKey", "A233");
			});
		}

		[TestMethod]
		public async Task GetRoad_TooManyRequests_ShouldThrowUnifiedApiException()
		{
			// Arrange
			var mockHttpClient = new Mock<IHttpClientWrapper>();
			mockHttpClient.Setup(x => x.GetAsync(It.IsAny<string>()))
				.ReturnsAsync(new HttpResponseMessage
				{
					StatusCode = HttpStatusCode.TooManyRequests
				});
			var apiClient = new ApiClient(mockHttpClient.Object);

			// Act and Assert
			await Assert.ThrowsExceptionAsync<UnifiedApiException>(async () =>
			{
				await apiClient.GetRoad("appKey", "A2");
			});
		}
	}
}