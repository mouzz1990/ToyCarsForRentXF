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
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToyCarsForRentXF.Droid
{
    [Service]
    class ToyCarTimerService : Service
    {
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            Task.Run(async () => {
                //Counter here
                int min = intent.GetIntExtra("minutes", 0);

                bool started = true;

                while (started)
                {
                    await Task.Delay((int)TimeSpan.FromMinutes(1).TotalMilliseconds);

                    min--;

                    if (min > 0)
                        Device.BeginInvokeOnMainThread(() => { MessagingCenter.Send<string>(min.ToString(), "TimerTicked"); });

                    else
                    {
                        Device.BeginInvokeOnMainThread(() => { MessagingCenter.Send<string>(min.ToString(), "TimerStopped"); });
                        started = false;
                    }
                }
            });

            return StartCommandResult.Sticky;
        }
    }
}