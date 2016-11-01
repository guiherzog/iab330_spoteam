using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Spoteam.Core.Utils;

namespace Spoteam_App.Utils {
    class Toast : IToast{
        private readonly Context _context;

        public Toast(Context context) {
            _context = context;
        }

        public void Show(string text) {
            Android.Widget.Toast.MakeText(_context, text, ToastLength.Short).Show();
        }

        public void ShowLong(string text) {
            Android.Widget.Toast.MakeText(_context, text, ToastLength.Long).Show();
        }
    }
}