using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakenbeheerCore.Team;

namespace TakenbeheerTesting.FakeRepos
{
    public class TeamRepository : ITeamRepository
    {
        public TeamDTO? GetTeamByEmployeeId(int employeeId)
        {
            return new TeamDTO(
                1,
                "Fontys",
                "Rachelsmolen 12",
                "4567 TU");
        }
        public bool EditTeamById(TeamDTO inputData)
        {
            if (inputData.Id > 3) return true;
            else return false;
        }
        public bool DeleteTeamById(int teamId)
        {
            return true;
        }
        public bool CreateTeam(TeamDTO inputData, int employeeId)
		{
			if (inputData.Id > 3) return true;
			else return false;
		}
    }
}
