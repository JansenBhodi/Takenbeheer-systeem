﻿using System;
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
            TeamModel result = null;
            try
            {
                TeamDTO input = _teamRepository.GetTeamByEmployeeId(employeeId);
                result = new TeamModel(
                    input.Id, 
                    input.Name,
                    input.Address,
                    input.PostalCode);
            }
            catch (Exception)
            {

                return null;
            }


            return result;
        }

    }
}
