using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;
using Spoteam.Core.Utils;
using Spoteam_App.Utils;

namespace Spoteam_App
{
    public class Setup : MvxAndroidSetup
    {
        private readonly Context _applicationContext;
        public Setup(Context applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        protected override IMvxApplication CreateApp()
        {
            return new Spoteam.Core.App();
        }

        protected override void InitializeFirstChance() {
            Mvx.RegisterSingleton<IToast>(new Toast(_applicationContext));
            base.InitializeFirstChance();
        }
    }
}
