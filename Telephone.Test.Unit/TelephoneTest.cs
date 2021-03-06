using System;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using NSubstitute;
using NUnit.Framework;
using Telephone.State_objects;

namespace Telephone.Test.Unit
{
    public class Tests
    {
        #region Setup
        private Telephone _uut;
        private TelephoneState _telephoneState;

        [SetUp]
        public void Setup()
        {
            _uut = new Telephone();
            _telephoneState = new Idle();
        }
        #endregion



        #region Test of state object: Idle
        [Test]
        public void InitState_TelephoneIdle()
        {
            Assert.That(_uut.GetState().ToString(), Is.EqualTo(new Idle().ToString()));
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        public void PhoneIdle_PressDigit_CorrectDigitPressed(int digit)
        {
            // Act
            _uut.PressDigit(digit);

            // Assert
            Assert.That(_uut.GetDigit, Is.EqualTo(digit));
        }

        [Test]
        public void PhoneIdle_PressCallButton_CorrectNumberCalled()
        {
            // Act
            _uut.PressDigit(1);
            _uut.PressDigit(2);
            _uut.PressDigit(3);
            _uut.PressDigit(4);
            _uut.PressCallButton();

            // Assert
            Assert.That(_uut.GetNumber, Is.EqualTo("1234"));
        }

        [Test]
        public void PhoneIdle_ForceDialNumber_ErrorMessage()
        {
            // Arrange
            TelephoneState fakeIdle = Substitute.For<TelephoneState>();
            _uut.SetState(fakeIdle);

            // Act
            _uut.DialNumber();

            // Assert
            fakeIdle.Received(1).HandleNumberDialed(_uut);
        }

        [Test]
        public void PhoneIdle_ForceEstablishConnection_ErrorMessage()
        {
            // Arrange
            TelephoneState fakeIdle = Substitute.For<TelephoneState>();
            _uut.SetState(fakeIdle);

            // Act
            _uut.EstablishConnection();

            // Assert
            fakeIdle.Received(1).HandleConnectionEstablished(_uut);
        }
        #endregion


        #region // Test of state object: Calling
        [Test]
        public void PhoneIdle_PressCallButton_StateChangedToCalling()
        {
            // Act
            _uut.PressCallButton();

            // Assert
            Assert.That(_uut.GetState().ToString(), Is.EqualTo(new Connected().ToString()));
        }
        #endregion


    }
}