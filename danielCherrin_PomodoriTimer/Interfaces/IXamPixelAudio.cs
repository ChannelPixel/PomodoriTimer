using System;
using System.Collections.Generic;
using System.Text;

namespace PomodoriTimer.Interfaces
{
    public interface IXamPixelAudio
    {
        bool PlayAudio(string filePath);
        bool PauseAudio();
        bool StopAudio();
        void SetVolume(float volume);
    }
}
