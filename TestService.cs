using System;
using System.Reactive.Linq;
using MvvmCross.ViewModels;

namespace NPCDemoBug1
{
    public class TestService : MvxNotifyPropertyChanged
    {
        public bool IsConnected { get; private set; }

        public TestService()
        {
            Observable.Interval(TimeSpan.FromSeconds(0.5)).Subscribe(x =>
            {
                IsConnected = !IsConnected;
            });
        }
    }
}