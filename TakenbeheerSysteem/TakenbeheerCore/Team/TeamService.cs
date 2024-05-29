using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakenbeheerCore.Errors;

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
                throw new DataNullException("Required data for retrieval is missing, check if a valid login has been executed.");
            }
            
            TeamModel result;
            TeamDTO? input;
            try
            {
                input = _teamRepository.GetTeamByEmployeeId(employeeId);
            }
            catch (Exception ex)
            {

                throw new DatabaseHandlerException("The repository failed to retrieve data from the database.", ex);
            }

            if (input == null)
            {
                throw new DataNullException("No data has been retrieved from the database.");
            }
            
            try
            {
                result = new TeamModel(input);
            }
            catch (Exception ex)
            {
                throw new DataConversionException("The data retrieved from the database does not match the expected criteria.", ex);
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
            if(ValidateTeamData(inputData))
            {
                try
                {
                    _teamRepository.EditTeamById(new TeamDTO(inputData));
                    return true;
                }
                catch (Exception ex)
                {
                    throw new DatabaseHandlerException("Repository failed to update database entry.", ex);
                }
            }
            return false;
        }

        public bool CreateTeam(TeamModel inputData, int employeeId)
        {
            if(ValidateTeamData(inputData))
            {
                try
                {
                    _teamRepository.CreateTeam(new TeamDTO(inputData), employeeId);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new DatabaseHandlerException("Repository failed to create database entry.", ex);

                }
            }
            return false;
        }

        public bool ValidateTeamData(TeamModel input)
        {
            //Can be expanded to check things like min/max length - certain rules used in database
            return (input.Id > 0 &&
                input.Name.Length > 0 &&
                input.Address.Length > 0 &&
                input.PostalCode.Length == 7);
        }
    }
}
