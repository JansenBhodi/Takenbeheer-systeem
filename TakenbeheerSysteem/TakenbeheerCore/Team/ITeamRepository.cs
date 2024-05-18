using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakenbeheerCore.Team
{
    public interface ITeamRepository
    {
        public TeamDTO? GetTeamByEmployeeId(int employeeId);
        public bool EditTeamById(TeamDTO inputData);
        public bool DeleteTeamById(int teamId);
        public bool CreateTeam(TeamDTO inputData, int employeeId);
    }
}
