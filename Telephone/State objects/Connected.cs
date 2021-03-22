using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephone.State_objects
{
    public class Connected : TelephoneState
    {
        public override void HandleDigitPressed(Telephone context)
        {
            Console.WriteLine("Biip. Error. Dial in progress");
        }

        public override void HandleButtonPressed(Telephone context)
        {
            Console.WriteLine("Call disconnecting");
            Console.WriteLine("Turning microphone off");
            context.MicrophoneOn = false;
            context.SetState(context.TelephoneDisconnecting());
            context.PressCallButton();
        }

        public override void HandleConnectionEstablished(Telephone context)
        {
            Console.WriteLine("Connection established");
        }

        public override void HandleNumberDialed(Telephone context)
        {
            Console.WriteLine("Error. Tried to dial number while dial was already in progress");

        }
    }
}
