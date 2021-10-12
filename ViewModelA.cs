using System;
using MvvmCross.ViewModels;
using PropertyChanged;

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
            
            _service.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "IsConnected")
                {
                    RaisePropertyChanged(nameof(IsConnected));
                }
            };

            PropertyChanged += (sender, args) =>
            {
                Console.WriteLine($"VM Property changed: {args.PropertyName}");
                
                switch (args.PropertyName)
                {
                    case nameof(IsConnected):
                        Console.WriteLine(IsConnected);
                        break;
                    case nameof(IsConnectedMessage):
                        Console.WriteLine(IsConnectedMessage);
                        break;
                }
                Console.WriteLine("");
            };
        }
    }
}