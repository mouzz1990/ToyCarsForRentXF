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
using ToyCarsForRentXF.Pictures;
using Xamarin.Forms;
using ToyCarsForRentXF.Droid;
using System.IO;
using System.Threading.Tasks;

[assembly:Dependency(typeof(PicturePicker_Android))]
namespace ToyCarsForRentXF.Droid
{
    public class PicturePicker_Android : IPicturePicker
    {
        public Task<Stream> GetImageStreamAsync()
        {
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);

            MainActivity activity = Forms.Context as MainActivity;

            activity.StartActivityForResult(Intent.CreateChooser(intent, "Select picture"), MainActivity.PickImageId);

            activity.PickImageTaskCompletionSource = new TaskCompletionSource<Stream>();

            return activity.PickImageTaskCompletionSource.Task;
        }
    }
}