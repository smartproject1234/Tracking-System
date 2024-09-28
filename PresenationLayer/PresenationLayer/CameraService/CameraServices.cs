using BusinessLayer.Services;
using Emgu.CV;
using System.Windows;
using Microsoft.Diagnostics.Tracing.StackSources;
using System.Security.Cryptography.X509Certificates;
using Xceed.Wpf.Toolkit;
using static System.Net.Mime.MediaTypeNames;


namespace PresenationLayer.CameraService
{
    public class CameraServices
    {
        private VideoCapture capture;
        private FaceRecognitionService faceRecognition;

        public CameraServices()
        {
            capture = new VideoCapture();
            faceRecognition = new FaceRecognitionService();

            
        }


        public void Start()
        {
            Application.Idle += ProcessFrame;

        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            var frame = capture.QueryFrame();

            if(faceRecognition.RecognizeFace(frame))
            {
                Console.WriteLine("Face recognized. Proceeding...");
            }

            else
            {
                Console.WriteLine("Error: Unauthorized face deteced. Closing project...");;

               Environment.Exit(0);
            }
        }
    }
}
