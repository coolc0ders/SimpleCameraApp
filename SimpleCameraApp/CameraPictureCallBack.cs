
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Hardware;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.IO;

namespace SimpleCameraApp
{
    public class CameraPictureCallBack : Java.Lang.Object, Camera.IPictureCallback
    {
        const string APP_NAME = "SimpleCameraApp";
        Context _context;

        public CameraPictureCallBack(Context cont)
        {
            _context = cont;
        }

        /// <summary>
        /// Callback when the picture is taken by the Camera
        /// </summary>
        /// <param name="data"></param>
        /// <param name="camera"></param>
        public void OnPictureTaken(byte[] data, Camera camera)
        {
            try
            {
                string fileName = Uri.Parse("test.jpg").LastPathSegment;
                var os = _context.OpenFileOutput(fileName, FileCreationMode.Private);
                System.IO.BinaryWriter binaryWriter = new System.IO.BinaryWriter(os);
                binaryWriter.Write(data);
                binaryWriter.Close();

                //We start the camera preview back since after taking a picture it freezes
                camera.StartPreview();
            }
            catch (System.Exception e)
            {
                Log.Debug(APP_NAME, "File not found: " + e.Message);
            }
        }
    }
}