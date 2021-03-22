using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephone.State_objects
{
    public class Idle : TelephoneState
    {
        public override void HandleDigitPressed(Telephone context)
        {
            Console.WriteLine($"Digit {context.GetDigit} pressed");
            context.AddDigit();
        }

        public override void HandleButtonPressed(Telephone context)
        {
            context.SetState(context.TelephoneCalling());
            context.DialNumber();
        }

        public override void HandleConnectionEstablished(Telephone context)
        {
            Console.WriteLine("Error. Tried to establish connection though call button was not pressed");
        }

        public override void HandleNumberDialed(Telephone context)
        {
            Console.WriteLine("Please press Call button to dial");
        }
    }
}
