using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class FaceRecognitionService
    {
        private CascadeClassifier faceCascade;

        public FaceRecognitionService()
        {
            faceCascade = new CascadeClassifier("haarcascade_frontalface_default.xml");

        }



        public bool RecognizeFace(Mat Frame)
        {
            var grayImage = new UMat();
            CvInvoke.CvtColor(Frame, grayImage, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
            var faces = faceCascade.DetectMultiScale(grayImage, 1.1,10, Size.Empty);

            return faces.Length > 0;

        }
    }
}
