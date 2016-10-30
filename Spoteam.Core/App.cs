using MvvmCross.Platform.IoC;
using Spoteam.Core.Helpers;
using Spoteam.Core.ViewModels;

namespace Spoteam.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            if (Settings.UserEmail != string.Empty && Settings.TeamId != 0)
                RegisterAppStart<TeamPageViewModel>();
            else
                RegisterAppStart<JoinTeamViewModel>();
        }
    }
}
