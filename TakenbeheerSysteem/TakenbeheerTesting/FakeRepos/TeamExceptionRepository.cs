using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakenbeheerCore.Team;

namespace TakenbeheerTesting.FakeRepos
{
    public class TeamExceptionRepository : ITeamRepository
    {
        public TeamDTO? GetTeamByEmployeeId(int employeeId)
        {
            if (employeeId == 1) throw new Exception();
            else if (employeeId == 2) return null;
            else return new TeamDTO(0, "", "", "");

        }
        public bool EditTeamById(TeamDTO inputData)
        {
            
           if(inputData.Id == 1) throw new Exception();
           else return false;
        }
        public bool DeleteTeamById(int teamId)
        {
           if(teamId == 1) throw new Exception();
           else return false;
        }
        public bool CreateTeam(TeamDTO inputData, int employeeId)
        {
            if (inputData.Id == 1) throw new Exception();
           else return false;
        }
    }
}
