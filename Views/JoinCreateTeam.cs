using Android.App;
using Android.Content;
using Android.Nfc;
using Android.OS;
using Android.Util;
using MvvmCross.Droid.Views;
namespace Spoteam_App.Views
{

    [Activity(Label = "Join Team")]
    public class JoinCreateTeam : MvxActivity
    {
		public NfcAdapter NFCdevice;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


			NfcManager NfcManager = (NfcManager)Android.App.Application.Context.GetSystemService(Context.NfcService);
			NFCdevice = NfcManager.DefaultAdapter;

            if(NFCdevice != null)
			    Log.Info("NFC Adapter",NFCdevice.ToString());

			SetContentView(Resource.Layout.JoinCreateTeam);
        }
    }
}