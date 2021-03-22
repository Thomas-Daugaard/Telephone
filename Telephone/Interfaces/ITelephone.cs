using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephone
{
    public interface ITelephone
    {
        public void PressDigit(int digit);
        public void PressCallButton();
        
    }
}
