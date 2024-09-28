using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class GestureRecogniitonService
    {
        private CascadeClassifier handCascade;

        public GestureRecogniitonService()
        {
            handCascade = new CascadeClassifier("haarcascade_hand.xml");

            //Jest için
    
        }

        public bool RecognizedeGesture(Mat frame)
        {
            var grayImage = new UMat();
            CvInvoke.CvtColor(frame, grayImage, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);

            var hands = handCascade.DetectMultiScale(grayImage, 1.1, 10, Size.Empty);

            return hands.Length > 0;
        }
    }

}
