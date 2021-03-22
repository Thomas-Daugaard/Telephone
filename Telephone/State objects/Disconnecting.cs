using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephone.State_objects
{
    public class Disconnecting : TelephoneState
    {
        public override void HandleDigitPressed(Telephone context)
        {
            Console.WriteLine("Please wait. Disconnecting");
        }

        public override void HandleButtonPressed(Telephone context)
        {
            Console.WriteLine("Disconnected");
            context.ClearNumber();
            context.SetState(context.TelephoneIdle());
        }

        public override void HandleConnectionEstablished(Telephone context)
        {
            Console.WriteLine("Error. Tried to establish connection while phone was disconnecting");
        }

        public override void HandleNumberDialed(Telephone context)
        {
            Console.WriteLine("Error. Tried to dial number while while phone was disconnecting");
        }
    }
}
