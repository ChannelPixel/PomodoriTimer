using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PomodoriTimer.UWP;
using PomodoriTimer.Interfaces;
using PomodoriTimer.UWP.DependencyClasses;
using Windows.Media.Playback;
using Windows.Media.Core;
using Windows.UI.Notifications;

[assembly: Dependency(typeof(XamPixelAudio))]
namespace PomodoriTimer.UWP.DependencyClasses
{
    class XamPixelAudio : IXamPixelAudio 
    {
        protected MediaPlayer PixelMediaPlayer;

        public XamPixelAudio()
        {
            PixelMediaPlayer = new MediaPlayer();
            PixelMediaPlayer.AutoPlay = false;
        }

        public bool PlayAudio(string filePath)
        {
            try
            {
                
                PixelMediaPlayer.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/"+filePath));
                PixelMediaPlayer.Play();
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
                if(PixelMediaPlayer.PlaybackSession.CanPause)
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
                if (PixelMediaPlayer.PlaybackSession.CanPause)
                {
                    PixelMediaPlayer.Pause();
                    PixelMediaPlayer.PlaybackSession.Position = new TimeSpan(0);
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
                PixelMediaPlayer.Volume = volume;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
