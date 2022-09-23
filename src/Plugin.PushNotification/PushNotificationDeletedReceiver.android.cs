﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Plugin.PushNotification
{
    [BroadcastReceiver(Exported = false)]
    public class PushNotificationDeletedReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>();
            var extras = intent.Extras;

            if (extras != null && !extras.IsEmpty)
            {
                foreach (var key in extras.KeySet())
                {
                    parameters.Add(key, $"{extras.Get(key)}");
                    System.Diagnostics.Debug.WriteLine(key, $"{extras.Get(key)}");
                }
            }

            PushNotificationManager.RegisterDelete(parameters);
        }
    }
}
