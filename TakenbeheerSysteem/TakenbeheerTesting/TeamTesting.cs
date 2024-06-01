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


        #endregion
        #region CreateTeam


        #endregion
        #region ValidateTeamData

        #endregion
        #region ValidateTeamDTO


        #endregion
    }
}