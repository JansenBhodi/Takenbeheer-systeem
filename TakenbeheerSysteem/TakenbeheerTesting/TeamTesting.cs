using TakenbeheerCore.Employee;
using TakenbeheerCore.Errors;
using TakenbeheerCore.Team;
using TakenbeheerTesting.FakeRepos;

namespace TakenbeheerTesting
{
    public class TeamTesting
    {

        private TeamService _service = new TeamService(new TeamRepository());
        private TeamService _exceptionService = new TeamService(new TeamExceptionRepository());
        #region GetTeamByEmployee
        [Fact]
        public void GetTeamTestIdIsZero()
        {
            Assert.Throws<DataNullException>(() => _service.GetTeamForEmployee(0));
        }
        [Fact]
        public void GetTeamTestHandleDatabaseFailure()
        {
            Assert.Throws<DatabaseHandlerException>(() => _exceptionService.GetTeamForEmployee(1));
        }
        [Fact]
        public void GetTeamTestInputIsNull()
        {
            Assert.Throws<DataNullException>(() => _exceptionService.GetTeamForEmployee(2));
        }
        [Fact]
        public void GetTeamTestConversionFailure()
        {
            Assert.Throws<DataConversionException>(() => _exceptionService.GetTeamForEmployee(5));
        }
        [Fact]
        public void GetTeamTestSuccesfullOutcome()
        {
            //Expected model info:
            //Id = 1
            //Name = Fontys
            //Address = Rachelsmolen 12
            //PostalCode = 4567 TU
            TeamModel? validator = new TeamModel(1, "Fontys", "Rachelsmolen 12", "4567 TU");

            TeamModel? outcome = _service.GetTeamForEmployee(4);

            Assert.NotNull(outcome);
            Assert.Equal(7, outcome.PostalCode.Count());
            Assert.Equivalent(validator, outcome);

            //Equivalent kan een IComparable implementeren zodat je zelf algoritmes kan toevoegen voor het vergelijken van modellen/data
        }
        #endregion
        #region DeleteTeam
        [Fact]
        public void DeleteTeamTestDatabaseFail()
        {
            Assert.Throws<DatabaseHandlerException>(() => _exceptionService.DeleteTeam(1));
        }
        [Fact]
        public void DeleteTeamTestReturnFalse()
        {
            Assert.Throws<DatabaseHandlerException>(() => _exceptionService.DeleteTeam(1));
        }
        [Fact]
        public void DeleteTeamTestReturnTrue()
        {
            Assert.True(_service.DeleteTeam(1));
        }
        #endregion
        #region UpdateTeam
        // Fail - false - true, validateTeamData skip
        // Check -> catch databasehandler, result status

        //Create a list of teams in the fake repository and update it in there, then throw back the result if that succeeded or not. good way to fake a database
        [Fact]
        public void UpdateTeamTestError()
        {
            Assert.Throws<DatabaseHandlerException>(() => _exceptionService.UpdateTeam(new TeamModel(1, "3465", "dgas", "1253 TW")));
        }
		[Fact]
		public void UpdateTeamTestTrue()
		{
            Assert.True(_service.UpdateTeam(new TeamModel(5, "Eindhovense Universiteit", "lampendriessen 31", "5642 RK")));
		}
		[Fact]
		public void UpdateTeamTestFalse()
		{
			Assert.False(_service.UpdateTeam(new TeamModel(1, "Eindhovense Universiteit", "lampendriessen 31", "5642 RK")));
		}

		#endregion
		#region CreateTeam
		[Fact]
		public void CreateTeamTestError()
		{
			Assert.Throws<DatabaseHandlerException>(() => _exceptionService.CreateTeam(new TeamModel(1, "3465", "dgas", "1253 TW"), 0));
		}
		[Fact]
		public void CreateTeamTestTrue()
		{
			Assert.True(_service.UpdateTeam(new TeamModel(6, "Eindhovense Universiteit", "lampendriessen 31", "5642 RK")));
		}
		[Fact]
		public void CreateTeamTestFalse()
		{
			Assert.False(_service.UpdateTeam(new TeamModel(1, "Fontys", "Rachelsmolen 12", "5642 RK")));
		}

		#endregion
		#region ValidateTeamData
		[Fact]
        public void ValidateTeamDataTestDataException()
        {
            TeamModel? test = null;

            Assert.Throws<InvalidDataException>(() => _exceptionService.ValidateTeamData(test));
        }

        [Fact]
        public void ValidateTeamDataTestFalse()
        {
            TeamModel test = new TeamModel(0, "", "", "2345RT");

            Assert.False(_exceptionService.ValidateTeamData(test));
        }

        [Fact]
        public void ValidateTeamDataTestTrue()
		{
			TeamModel test = new TeamModel(5, "Johnson Peter", "Valley Road 15", "2345 RT");

			Assert.True(_exceptionService.ValidateTeamData(test));
		}

		#endregion
		#region ValidateTeamDTO

		[Fact]
		public void ValidateTeamDTOTestDataException()
		{
            TeamDTO? test = null;

			Assert.Throws<InvalidDataException>(() => _exceptionService.ValidateTeamDTO(test));
		}

		[Fact]
		public void ValidateTeamDTOTestFalse()
		{
			TeamDTO test = new TeamDTO(0, "", "", "2345RT");

			Assert.False(_exceptionService.ValidateTeamDTO(test));
		}

		[Fact]
		public void ValidateTeamDTOTestTrue()
		{
			TeamDTO test = new TeamDTO(5, "Johnson Peter", "Valley Road 15", "2345 RT");

			Assert.True(_exceptionService.ValidateTeamDTO(test));
		}
		#endregion
	}
}