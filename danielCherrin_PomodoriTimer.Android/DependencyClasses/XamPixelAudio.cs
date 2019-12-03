using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PomodoriTimer.Droid;
using PomodoriTimer.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(XamPixelAudio))]
namespace PomodoriTimer.Droid
{
    public class XamPixelAudio : IXamPixelAudio
    {
        protected MediaPlayer PixelMediaPlayer;

        public XamPixelAudio()
        {
            PixelMediaPlayer = new MediaPlayer();
        }

        public bool PlayAudio(string filePath)
        {
            try
            {
                PixelMediaPlayer.Reset();
                var fd = global::Android.App.Application.Context.Assets.OpenFd(filePath);
                PixelMediaPlayer.SetDataSource(fd.FileDescriptor, fd.StartOffset, fd.Length);
                PixelMediaPlayer.Prepare();
                PixelMediaPlayer.Start();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool PauseAudio()
        {
            try
            {
                if (PixelMediaPlayer.IsPlaying)
                {
                    PixelMediaPlayer.Pause();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool StopAudio()
        {
            try
            {
                if (PixelMediaPlayer.IsPlaying)
                {
                    PixelMediaPlayer.Stop();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public void SetVolume(float volume)
        { 
            try
            {
                PixelMediaPlayer.SetVolume(volume, volume);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}