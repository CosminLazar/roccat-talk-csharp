using System;

namespace Roccat_Talk.RyosTalkFX
{
    public class KeyboardState
    {
        protected readonly bool[] LedState;

        /// <summary>
        /// Creates a fresh instance of the <see cref="KeyboardState"/> with all keys turned off
        /// </summary>
        /// <param name="noOfKeys">The number of keys present on the keyboard</param>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="noOfKeys"/> is a number less than zero</exception>
        public KeyboardState(int noOfKeys = 110)
        {
            if (noOfKeys < 0)
                throw new ArgumentOutOfRangeException("noOfKeys");

            LedState = new bool[noOfKeys];
        }

        /// <summary>
        /// Creates a fresh instance of the <see cref="KeyboardState"/> using a previous state
        /// </summary>
        /// <param name="ledState"></param>
        /// <exception cref="ArgumentNullException">When <paramref name="ledState"/> is a null reference</exception>
        public KeyboardState(bool[] ledState)
        {
            if (ledState == null) throw new ArgumentNullException("ledState");

            LedState = ledState;
        }

        /// <summary>
        /// Turns all the keys on
        /// </summary>
        public virtual void AllLedsOn()
        {
            for (var i = 0; i < LedState.Length; i++)
            {
                LedState[i] = true;
            }
        }

        /// <summary>
        /// Turns all the keys off
        /// </summary>
        public virtual void AllLedssOff()
        {
            for (var i = 0; i < LedState.Length; i++)
            {
                LedState[i] = false;
            }
        }

        /// <summary>
        /// Turns the specified key on
        /// </summary>
        /// <param name="key"></param>
        /// <exception cref="ArgumentOutOfRangeException">When the specified key cannot be accommodated by the current instance</exception>
        public virtual void SetLedOn(Key key)
        {
            AssertKeyIsPartOfKeyboard(key);

            LedState[key.Code] = true;
        }

        /// <summary>
        /// Turns the specified key off
        /// </summary>
        /// <param name="key"></param>
        /// <exception cref="ArgumentOutOfRangeException">When the specified key cannot be accommodated by the current instance</exception>
        public virtual void SetLedOff(Key key)
        {
            AssertKeyIsPartOfKeyboard(key);

            LedState[key.Code] = false;
        }

        /// <summary>
        /// Returns whether the Led of the specified <paramref name="key"/> is on
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Returns the LED state of the specified <paramref name="key"/> in the current keyboard state</returns>
        /// <exception cref="ArgumentOutOfRangeException">When the specified key cannot be accommodated by the current instance</exception>
        public virtual bool IsLedOn(Key key)
        {
            AssertKeyIsPartOfKeyboard(key);

            return LedState[key.Code];
        }

        /// <summary>
        /// Returns an array containing the illumination state for each key. 
        /// The index represents the Key code. 
        /// </summary>
        /// <returns></returns>
        public virtual bool[] GetCurrentState()
        {
            var stateAtThisPoint = new bool[LedState.Length];
            Array.Copy(LedState, stateAtThisPoint, LedState.Length);
            
            return stateAtThisPoint;
        }

        protected virtual void AssertKeyIsPartOfKeyboard(Key key)
        {
            if (key.Code >= LedState.Length)
                throw new ArgumentOutOfRangeException("key", string.Format("The specified key cannot be accommodated by the current keyboard. Maximum supported key code for the current instance is: {0}", LedState.Length - 1));
        }
    }
}
