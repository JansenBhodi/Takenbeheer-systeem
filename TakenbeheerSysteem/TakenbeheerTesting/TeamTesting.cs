using TakenbeheerCore.Employee;
using TakenbeheerCore.Team;
using TakenbeheerTesting.FakeRepos;

namespace TakenbeheerTesting
{
    public class TeamTesting
    {

        private TeamService _service = new TeamService(new TeamRepository());
        private TeamService _exceptionService = new TeamService(new TeamExceptionRepository());

        [Fact]
        public void Test1()
        {

        }
    }
}