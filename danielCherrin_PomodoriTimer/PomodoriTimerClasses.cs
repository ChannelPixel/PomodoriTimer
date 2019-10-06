using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace danielCherrin_PomodoriTimer
{
    internal static class PomodoriTimerAPI
    {
        public static int DefaultPomLength = 25;
        public static int DefaultBreakLength = 5;
        public static int DefaultLongBreakLength = 30;

        public static void RefreshDynamicThemeResources(bool IsDarkTheme)
        {
            if(IsDarkTheme)
            {
                Application.Current.Resources["Color_Main"] = ColorConverters.FromHex("#f1f1f1");
                Application.Current.Resources["Color_Secondary"] = ColorConverters.FromHex("#1a1a1a");
            }
            else
            {
                Application.Current.Resources["Color_Main"] = ColorConverters.FromHex("#1a1a1a");
                Application.Current.Resources["Color_Secondary"] = ColorConverters.FromHex("#f1f1f1");
            }
        }
    }

    internal class PomodoriUserTimer : INotifyPropertyChanged
    {
        #region Properties
        #region CurrentUserTimeSpan
        private TimeSpan _CurrentSpan;
        public TimeSpan CurrentSpan
        {
            get { return _CurrentSpan; }
            set
            {
                _CurrentSpan = value;
                OnPropertyChanged("CurrentUserTimer");
            }
        }
        #endregion
        #region PomLength
        private int _PomLength;
        public int PomLength
        {
            get { return _PomLength; }
            set
            {
                _PomLength = value;
                OnPropertyChanged("PomLength");
            }
        }
        #endregion
        #region BreakLength
        private int _BreakLength;
        public int BreakLength
        {
            get { return _BreakLength; }
            set
            {
                _BreakLength = value;
                OnPropertyChanged("BreakLength");
            }
        }
        #endregion
        #region LongBreakLength
        private int _LongBreakLength;
        public int LongBreakLength
        {
            get { return _LongBreakLength; }
            set
            {
                _LongBreakLength = value;
                OnPropertyChanged("LongBreakLength");
            }
        }
        #endregion
        #region CurrentTimerState
        private int _CurrentTimerState;
        public int CurrentTimerState
        {
            get { return _CurrentTimerState; }
            set
            {
                _CurrentTimerState = value;
                OnPropertyChanged("CurrentTimerState");
            }
        }
        #endregion
        #region Counting
        private bool _Counting;
        public bool Counting
        {
            get { return _Counting; }
            set
            {
                _Counting = value;
                OnPropertyChanged("Counting");
            }
        }
        #endregion
        #region UseDarkTheme
        private bool _UseDarkTheme;
        public bool UseDarkTheme
        {
            get { return _UseDarkTheme; }
            set
            {
                _UseDarkTheme = value;
                OnPropertyChanged("UseDarkTheme");
            }
        }
        #endregion 
        #endregion

        #region Constructors
        public PomodoriUserTimer()
        {
            this.PomLength = PomodoriTimerAPI.DefaultPomLength;
            this.BreakLength = PomodoriTimerAPI.DefaultBreakLength;
            this.LongBreakLength = PomodoriTimerAPI.DefaultLongBreakLength;
            CurrentTimerState = 0;
            Counting = false;
            CurrentSpan = new TimeSpan(0, PomLength, 0);
            UseDarkTheme = true;
        }
        public PomodoriUserTimer(int pomLength, int breakLength, int longBreakLength)
        {
            this.PomLength = pomLength;
            this.BreakLength = breakLength;
            this.LongBreakLength = longBreakLength;
            CurrentTimerState = 0;
            Counting = false;
            CurrentSpan = new TimeSpan(0, PomLength, 0);
            UseDarkTheme = true;
        }

        public PomodoriUserTimer(int pomLength, int breakLength, int longBreakLength, bool useDarkTheme)
        {
            this.PomLength = pomLength;
            this.BreakLength = breakLength;
            this.LongBreakLength = longBreakLength;
            CurrentTimerState = 0;
            Counting = false;
            CurrentSpan = new TimeSpan(0, PomLength, 0);
            UseDarkTheme = useDarkTheme;
            PomodoriTimerAPI.RefreshDynamicThemeResources(UseDarkTheme);
        }
        #endregion

        public enum TimerState
        {
            FirstPom,
            FirstBreak,
            SecondPom,
            SecondBreak,
            ThirdPom,
            ThirdBreak,
            FourthPom,
            FourthBreak,
        }

        internal void ToggleCounting()
        {
            Counting = !Counting;
        }

        internal void PrevTimerState()
        {
            if (CurrentTimerState <= 0)
            {
                CurrentTimerState = 8;
                RefreshTimerState();
            }
            else
            {
                CurrentTimerState--;
                RefreshTimerState();
            }
        }

        internal void NextTimerState()
        {
            if (CurrentTimerState >= 8)
            {
                CurrentTimerState = 0;
                RefreshTimerState();
            }
            else
            {
                CurrentTimerState++;
                RefreshTimerState();
            }
        }

        internal void RefreshTimerState()
        {
            //Set timer to pom
            if (CurrentTimerState == 0
                || CurrentTimerState == 2
                || CurrentTimerState == 4
                || CurrentTimerState == 6)
            {
                CurrentSpan = new TimeSpan(0, PomLength, 0);
            }
            //Set timer to break
            else if (CurrentTimerState == 1
                    || CurrentTimerState == 3
                    || CurrentTimerState == 5
                    || CurrentTimerState == 7)
            {
                CurrentSpan = new TimeSpan(0, BreakLength, 0);
            }
            //Set timer to long break
            else if (CurrentTimerState == 8)
            {
                CurrentSpan = new TimeSpan(0, LongBreakLength, 0);
            }
        }

        internal void JumpToTimerState(int jumpToState)
        {
            if(!(jumpToState < 0) && !(jumpToState > 8))
            {
                CurrentTimerState = jumpToState;
                RefreshTimerState();
            }
            else
            {
                throw new ArgumentException("Parameter is out of possible timer state ranges", "jumpToState");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        // Create the OnPropertyChanged method to raise the event
        internal void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
