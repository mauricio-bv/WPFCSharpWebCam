﻿using System;
using System.IO;
using System.Linq;
using System.Text;
using WebCam_Capture;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media;


namespace WPFCSharpWebCam
{
    //Design by Pongsakorn Poosankam
    class WebCam
    {
        private WebCamCapture webcam;
        private System.Windows.Controls.Image _FrameImage;
        private int FrameNumber = 30;
        Window1 wnd;
        public static Bitmap capturedBitmap;
        public void InitializeWebCam(ref System.Windows.Controls.Image ImageControl, Window1 window)
        {
            webcam = new WebCamCapture();
            webcam.FrameNumber = ((ulong)(0ul));
            webcam.TimeToCapture_milliseconds = FrameNumber;
            webcam.ImageCaptured += new WebCamCapture.WebCamEventHandler(webcam_ImageCaptured);
            _FrameImage = ImageControl;
            wnd = window;
        }

        void webcam_ImageCaptured(object source, WebcamEventArgs e)
        {
            MotionDetection.OldDetection(e, wnd);
            _FrameImage.Source = Helper.LoadBitmap((System.Drawing.Bitmap)e.WebCamImage);
           // capturedBitmap = (System.Drawing.Bitmap)e.WebCamImage;
        }

       
        public void Start()
        {
            webcam.TimeToCapture_milliseconds = FrameNumber;
            webcam.Start(0);
        }

        public void Stop()
        {
            webcam.Stop();
        }

        public void Continue()
        {
            // change the capture time frame
            webcam.TimeToCapture_milliseconds = FrameNumber;

            // resume the video capture from the stop
            webcam.Start(this.webcam.FrameNumber);
        }

        public void ResolutionSetting()
        {
            webcam.Config();
        }

        public void AdvanceSetting()
        {
            webcam.Config2();
        }

    }
}
