using Screen.Api.Interfaces;
using Screen.Api.Repository;

namespace Screen.Api.Tests.Repository;

[TestClass]
public class ConservicesGameRepositoryTests
{
	private readonly IConservicesGameRepository _conservicesGameRepository = new ConservicesGameRepository();
	
	[TestMethod]
	public async Task GetAllGames_ReturnsListOfGames()
	{
		var result = await _conservicesGameRepository.GetAllGames("c0689650-3dbe-43c5-b9d0-7795b597774f");
		
		Assert.IsTrue(result.Count > 0);
	}
}