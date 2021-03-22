using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephone.State_objects;

namespace Telephone
{
    public class Telephone : ITelephone
    {
        #region State objects
        private TelephoneState Idle;
        private TelephoneState Calling;
        private TelephoneState Connected;
        private TelephoneState Disconnecting;
        #endregion

        #region Other fields
        private TelephoneState State;
        private string Number;
        private int digit;

        #endregion

        public TelephoneState GetState() => State;

        public string GetNumber => Number;
        public int GetDigit => digit;
        public bool MicrophoneOn { get; set; }

        public Telephone()
        {
            Idle = new Idle();
            Calling = new Calling();
            Connected = new Connected();
            Disconnecting = new Disconnecting();
            State = Idle;
            Number = "";
            MicrophoneOn = false;
        }

        public void PressDigit(int digit)
        {
            this.digit = digit;
            State.HandleDigitPressed(this);
        }

        public void PressCallButton()
        {
            State.HandleButtonPressed(this);
        }

        public void EstablishConnection()
        {
            State.HandleConnectionEstablished(this);
        }

        public void DialNumber()
        {
            State.HandleNumberDialed(this);
        }

        public void AddDigit()
        {
            Number += digit.ToString();
        }

        public void ClearNumber()
        {
            Number = "";
        }

        #region State Getters
        public TelephoneState TelephoneCalling() => Calling;

        public TelephoneState TelephoneConnected() => Connected;
        
        public TelephoneState TelephoneDisconnecting() => Disconnecting;

        public TelephoneState TelephoneIdle() => Idle;
        
        #endregion

        public void SetState(TelephoneState s)
        {
            State = s;
        }
    }
}
