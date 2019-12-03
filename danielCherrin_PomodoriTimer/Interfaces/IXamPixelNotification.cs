using System;
using System.Collections.Generic;
using System.Text;

namespace PomodoriTimer.Interfaces
{
    public interface IXamPixelNotification
    {
        bool ShowNotification(string title, string stringContent); 
    }
}
