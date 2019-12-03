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
        internal static int DefaultPomLength = 25;
        internal static int DefaultBreakLength = 5;
        internal static int DefaultLongBreakLength = 30;

        internal static void RefreshDynamicThemeResources(bool IsDarkTheme)
        {
            if (IsDarkTheme)
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

        internal static string[] producivityQuotes = new string[]
        {"“Productivity is being able to do things that you were never able to do before.” - Franz Kafka",
            "“Until we can manage time, we can manage nothing else.” - Peter Drucker",
            "“If you spend too much time thinking about a thing, you’ll never get it done.” - Bruce Lee",
            "“Your mind is for having ideas, not holding them.” - David Allen",
            "“Nothing is less productive than to make more efficient what should not be done at all.” - Peter Drucker",
            "“Time is the scarcest resource and unless it is managed nothing else can be managed” - Peter Drucker",
            "“Focus on being productive instead of busy.” - Tim Ferriss",
            "“Time is at once the most valuable and the most perishable of all our possessions” - John Randolph",
            "“Absorb what is useful, reject what is useless, add what is specifically your own.” - Bruce Lee",
            "“Efficiency is doing better what is already being done.” - Peter Drucker",
            "“Do not squander time for that is the stuff life is made of.” - Benjamin Franklin",
            "“Lost time is never found again.” - Benjamin Franklin",
            "“The desire of knowledge, like the thirst for riches, increases ever with the acquisition of it.” - Laurence Sterne",
            "“By failing to prepare, you are preparing to fail.” - Benjamin Franklin",
            "“You don’t need a new plan for next year. You need a commitment.” - Seth Godin",
            "“Long-range planning works best in the short term.” - Doug Evelyn",
            "“If there are nine rabbits on the ground, if you want to catch one, just focus on one.” - Jack Ma",
            "“When one has much to put into them, a day has a hundred pockets.” - Friedrich Nietzsche",
            "“Working on the right thing is probably more important than working hard.” - Caterina Fake",
            "“Time is the school in which we learn, time is the fire in which we burn.” - Delmore Schwartz",
            "“There is no substitute for hard work.” - Thomas Edison",
            "“Action is the foundational key to all success.” - Picasso",
            "“Never mistake motion for action.” - Ernest Hemingway",
            "“While one person hesitates because he feels inferior, the other is busy making mistakes and becoming superior.” - Henry Link",
            "“My goal is no longer to get more done, but rather to have less to do.” - Francine Jay",
            "“Concentrate all your thoughts upon the work in hand. The sun’s rays do not burn until brought to a focus.” - Alexander Graham Bell",
            "“The only way around is through.” - Robert Frost",
            "“Improved productivity means less human sweat, not more.” - Henry Ford",
            "“You must remain focused on your journey to greatness.” - Les Brown",
            "“Anyone who has never made a mistake has never tried anything new.” - Albert Einstein",
            "“If you’re walking down the right path and you’re willing to keep walking, eventually you’ll make progress.” - Barack Obama",
            "“The way to get started is to quit talking and begin doing.” - Walt Disney",
            "“Glory lies in the attempt to reach one’s goal and not in reaching it.” - Mahatma Ghandi",
            "“The secret of getting ahead is getting started.” - Mark Twain",
            "“It is no good getting furious if you get stuck. What I do is keep thinking about the problem but work on something else.” - Stephen Hawking",
            "“Don’t count the days. Make the days count.” - Muhammad Ali",
            "“You can, you should, and if you’re brave enough to start, you will.” - Steven King",
            "“If you have to eat two frogs, eat the ugliest one first.” - Brian Tracy",
            "“Just do it! - Shia LaBeouf”",
            "“Tomorrow becomes never. No matter how small the task, take the first step now!” - Tim Ferriss",
            "“Art is the elimination of the unnecessary.” - Pablo Picasso",
            "“In life, people tend to wait for good things to come to them. And by waiting, they miss out.” - Neil Strauss",
            "“The only way you are going to have success is to have lots of failures first.” - Sergey Brin",
            "“Don’t ask. Act! Action will delineate and define you” - Thomas Jefferson",
            "“It’s not that I’m so smart, it’s just that I stay with problems longer.” – Albert Einstein",
            "“You were born to win, but to be a winner, you must plan to win, prepare to win, and expect to win.” – Zig Ziglar",
            "“Sometimes, things may not go your way, but the effort should be there every single night.” – Michael Jordan",
            "“How poor are they that have not patience! What wound did ever heal but by degrees?” – William Shakespeare",
            "“A wind that blows aimlessly is no good to anyone.” – Rick Riord​an",
            "“Far and away the best prize that life offers is the chance to work hard at work worth doing.” – Theodore Roosevelt",
            "“It's hard to beat a person who never gives up.” – Babe Ruth"
        };
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
        #region UseAlarmNotification
        private bool _UseAlarmNotification;
        public bool UseAlarmNotification
        {
            get { return _UseAlarmNotification; }
            set
            {
                _UseAlarmNotification = value;
                OnPropertyChanged("UseAlarmNotification");
            }
        }
        #endregion
        #region UseAlarmSound
        private bool _UseAlarmSound;
        public bool UseAlarmSound
        {
            get { return _UseAlarmSound; }
            set
            {
                _UseAlarmSound = value;
                OnPropertyChanged("UseAlarmSound");
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
            UseAlarmNotification = true;
            UseAlarmSound = true;
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
            UseAlarmNotification = true;
            UseAlarmSound = true;
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
            UseAlarmNotification = true;
            UseAlarmSound = true;
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
