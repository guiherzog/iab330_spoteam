using Android.App;
using Android.OS;
using Android.Nfc;
using MvvmCross.Droid.Views;
using Android.Util;
using Android.Content;
using System;
using MvvmCross.Plugins.Messenger;
using MvvmCross.Platform;

namespace Spoteam_App.Views
{
	[Activity(Label = "Update Location")]
	public class Update : MvxActivity
	{
		public NfcAdapter NFCdevice;
		private readonly IMvxMessenger _messenger = Mvx.Resolve<IMvxMessenger>();

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Update);

			NfcManager NfcManager = (NfcManager)Application.Context.GetSystemService(Context.NfcService);
			NFCdevice = NfcManager.DefaultAdapter;

			if (NFCdevice != null && NFCdevice.IsEnabled)
				Log.Debug("NFC Adapter exists and is enabled", NFCdevice.ToString());
		}

		protected override void OnPause()
		{
			base.OnPause();
			if (IsSupported)
				NFCdevice.DisableForegroundDispatch(this);
		}

		public bool IsSupported
		{
			get
			{
				return NFCdevice != null && NFCdevice.IsEnabled;
			}
		}

		protected override void OnResume()
		{
			base.OnResume();
			if (IsSupported)
			{
				var pendingIntent = PendingIntent.GetActivity(this, 0, new Intent(this, Class).AddFlags(ActivityFlags.SingleTop),
																   (PendingIntentFlags)0);
			
            	var tagDetected = new IntentFilter(NfcAdapter.ActionTagDiscovered);
				var filters = new[] { tagDetected };

				NFCdevice.EnableForegroundDispatch(this, pendingIntent, filters, null);
			}
		}

		protected override void OnNewIntent(Intent intent)
		{
			base.OnNewIntent(intent);

			var tagAsObj = (Tag)intent.GetParcelableExtra(NfcAdapter.ExtraTag);

			string id = string.Empty;
			if (tagAsObj != null)
			{
				Tag tag = tagAsObj as Tag;
				byte[] idAsByte = tag.GetId();

				id = BitConverter.ToString(idAsByte);
			}

			var nfcMessage = new NFCMessage(this, id);

			_messenger.Publish(nfcMessage);

		}


	}
}
