using System;
using System.Threading;
using System.Timers;

namespace Telephone.State_objects
{
    public class Calling : TelephoneState
    {
        public override void HandleDigitPressed(Telephone context)
        {
            Console.WriteLine("Error. Phone dialing.");
        }

        public override void HandleButtonPressed(Telephone context)
        {
            Console.WriteLine("Dial aborted");
            Console.WriteLine("Turning microphone off");
            context.MicrophoneOn = false;
            context.SetState(context.TelephoneIdle());
        }

        public override void HandleConnectionEstablished(Telephone context)
        {
            Console.WriteLine("Error. Tried to establish another connection while phone was trying to connect");
        }

        public override void HandleNumberDialed(Telephone context)
        {
            Console.WriteLine($"Dialing number {context.GetNumber}");
            Console.WriteLine("Turning microphone on");
            context.MicrophoneOn = true;

            Thread.Sleep(3000);

            context.SetState(context.TelephoneConnected());
            context.EstablishConnection();
        }
    }
}
