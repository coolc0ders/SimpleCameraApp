using Android.App;
using Android.Widget;
using Android.OS;

namespace SimpleCameraApp
{
    [Activity(Label = "SimpleCameraApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            FragmentManager.BeginTransaction()
               .Replace(Resource.Id.content_frame, new CameraFragment())
               .Commit();
        }
    }
}

