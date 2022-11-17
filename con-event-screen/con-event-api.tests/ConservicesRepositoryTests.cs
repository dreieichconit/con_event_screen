using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace con_event_api.tests;

[TestClass]
public class ConservicesRepositoryTests
{
    [TestMethod]
    public void GetGames()
    {
        var games = Task.Run(async () => await ConservicesRepository.GetGamesAsync()).Result;
    }
}