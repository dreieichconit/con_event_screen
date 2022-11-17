using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace con_event_api.tests;

[TestClass]
public class HomepageRepositoryTests
{
	[TestMethod]
	public void GetProgramTest()
	{
		Trace.WriteLine(Task.Run(async () => await HomepageRepository.GetProgramAsync()).Result);
	}
}