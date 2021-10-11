using System;
using System.Reactive.Linq;
using MvvmCross.ViewModels;
using PropertyChanged;
using ReactiveUI;

namespace NPCDemoBug1
{
    public class ViewModelA : MvxNotifyPropertyChanged
    {
        public bool IsConnected => _service.IsConnected;
        
        [DependsOn(nameof(IsConnected))]
        public string IsConnectedMessage => IsConnected ? "Is Connected" : "Is NOT Connected";

        private readonly TestService _service;
        
        public ViewModelA(TestService service)
        {
            _service = service;
            
            // this was my clever way of a "DependsOn" that links to another object.
            // But apparently this causes issues with the DependsOn attribute
            _service.ObservableForProperty(x => x.IsConnected)
                .ToPropertyChanged(this, x => x.IsConnected);

            PropertyChanged += (sender, args) => { Console.WriteLine($"property changed: {args.PropertyName}"); };

            this.WhenAnyValue(x => x.IsConnectedMessage).Subscribe(Console.WriteLine);
        }
    }
}