using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;

namespace MYSCHOOLFINAL
{
    public class GifImage
    {
        private Image gifImage;
        private FrameDimension dimension;
        private int framecount;
        private int currentFrame = -1;
        private bool reverse;
        private int step = 1;
        public GifImage(string path)
        {
            gifImage = Image.FromFile(path);
            //initialize
            dimension = new FrameDimension(gifImage.FrameDimensionsList[0]);
            //gets the GUID
            //total frames in the animation
            framecount = gifImage.GetFrameCount(dimension);
        }
        public bool ReverseAtEnd
        {
            //wether the gif should play bachward when it reaches the end
            get { return reverse; }
            set { reverse = value; }
        }
        public Image GetNextFrame()
        {

            currentFrame += step;
            //if animatin reaches a boundary...
            if (currentFrame >= framecount || currentFrame < 0)
            {

                if (reverse)
                {
                    step *= -1;
                    //reverse the cunt 
                    //apply it
                }
                else
                {
                    currentFrame = 0;
                    //or start over
                }
            }
            return GetFrame(currentFrame);
        }
        public Image GetFrame(int index)
        {
            gifImage.SelectActiveFrame(dimension, index);
            //find the frame 
            return (Image)gifImage.Clone();
            //retrun or copy it
        }
    }
}
