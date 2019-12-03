using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Notifications;
using Microsoft.QueryStringDotNET;
using PomodoriTimer.Interfaces;
using PomodoriTimer.UWP.DependencyClasses;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Xamarin.Forms;

[assembly: Dependency(typeof(XamPixelAudio))]
namespace PomodoriTimer.UWP
{
    class XamPixelNotification: IXamPixelNotification
    {
        ToastNotification Toast;

        public bool ShowNotification(string title, string stringContent)
        {
            try
            {
                Toast = new ToastNotification(ConstructToastContent(title, stringContent).GetXml());
                ToastNotificationManager.CreateToastNotifier().Show(Toast);

                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        ToastVisual ConstructToastVisual(string title, string stringContent)
        {
            ToastVisual visual = new ToastVisual()
            {
                BindingGeneric = new ToastBindingGeneric()
                {
                    Children =
                    {
                        new AdaptiveText()
                        {
                            Text = title
                        },

                        new AdaptiveText()
                        {
                            Text = stringContent
                        }
                    }
                }
            };

            return visual;
        }

        ToastActionsCustom ConstructToastActions()
        {
            ToastActionsCustom actions = new ToastActionsCustom()
            {
                Buttons =
                {
                    new ToastButton("Continue", new QueryString()
                    {
                        { "action", "continue" }
                    }.ToString())
                    {
                        ActivationType = ToastActivationType.Background,
                    },

                    new ToastButton("Dismiss", new QueryString()
                    {
                        { "action", "dismiss" }
                    }.ToString())
                    {
                        ActivationType = ToastActivationType.Background,
                    }
                }
            };

            return actions;
        }

        ToastContent ConstructToastContent(string title, string stringContent)
        {
            ToastContent content = new ToastContent()
            {
                Visual = ConstructToastVisual(title, stringContent),
                Actions = ConstructToastActions(),

                Launch = new QueryString()
                {
                    { "action", "viewConversation" }
                }.ToString()
            };

            return content;
        }
    }
}
