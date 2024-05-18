using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakenbeheerCore.Team
{
    public class TeamService
    {
        private ITeamRepository _teamRepository;
        public TeamService(ITeamRepository repo) 
        {
            _teamRepository = repo;
        }

        public TeamModel? GetTeamForEmployee(int employeeId)
        {
            if (employeeId == 0)
            {
                return null;
            }
            TeamModel result;
            try
            {
                TeamDTO input = _teamRepository.GetTeamByEmployeeId(employeeId);
                result = new TeamModel(input);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public bool DeleteTeam(int teamId)
        {
            try
            {
                _teamRepository.DeleteTeamById(teamId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateTeam(TeamModel inputData)
        {
            try
            {
                _teamRepository.EditTeamById(new TeamDTO(inputData));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CreateTeam(TeamModel inputData, int employeeId)
        {
            try
            {
                _teamRepository.CreateTeam(new TeamDTO(inputData), employeeId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
