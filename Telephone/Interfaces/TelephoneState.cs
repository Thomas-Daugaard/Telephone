using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephone
{
    public abstract class TelephoneState
    {
        public abstract void HandleDigitPressed(Telephone context);
        public abstract void HandleButtonPressed(Telephone context);
        public abstract void HandleConnectionEstablished(Telephone context);
        public abstract void HandleNumberDialed(Telephone context);
    }
}
