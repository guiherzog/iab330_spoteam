using Android.App;
using Android.Content;
using Android.Nfc;
using Android.OS;
using Android.Util;
using MvvmCross.Droid.Views;
namespace Spoteam_App.Views
{

    [Activity(Label = "Join Team")]
    public class JoinTeam : MvxActivity
    {
		public NfcAdapter NFCdevice;

        protected override void OnCreate(Bundle join)
        {
            base.OnCreate(join);


			NfcManager NfcManager = (NfcManager)Android.App.Application.Context.GetSystemService(Context.NfcService);
			NFCdevice = NfcManager.DefaultAdapter;

			Log.Info("NFC Adapter",NFCdevice.ToString());

			SetContentView(Resource.Layout.Join);
        }
    }
}
