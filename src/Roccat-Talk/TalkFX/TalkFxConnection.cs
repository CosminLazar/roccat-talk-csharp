using System;

namespace Roccat_Talk.TalkFX
{
    /// <summary>
    /// Allows LED illumination configuration on all the TalkFX capable devices.
    /// Requires ROCCAT Talk to be installed and running.
    /// </summary>
    public class TalkFxConnection : BasicTalkFxConnection
    {
        private readonly Action<IntPtr, byte, byte, byte, byte, byte, byte> _set_LED_RGB;
        private readonly Action<IntPtr> _restore_LED_RGB;
        
        public TalkFxConnection()
        {
            if (Environment.Is64BitProcess)
            {
                _set_LED_RGB = TalkFxBindings.TalkFX.Set_LED_RGB_x64;
                _restore_LED_RGB = TalkFxBindings.TalkFX.RestoreLEDRGB_x64;                
            }
            else
            {
                _set_LED_RGB = TalkFxBindings.TalkFX.Set_LED_RGB_x86;
                _restore_LED_RGB = TalkFxBindings.TalkFX.RestoreLEDRGB_x86;
            }
        }

        /// <summary>
        /// Sends the specified keyboard illumination configuration
        /// </summary>
        /// <param name="zone"></param>
        /// <param name="keyEffect"></param>
        /// <param name="speed"></param>
        /// <param name="color"></param>
        public void SetLedRgb(Zone zone, KeyEffect keyEffect, Speed speed, Color color)
        {
            _set_LED_RGB(RoccatHandle, (byte)zone, (byte)keyEffect, (byte)speed, color.Red, color.Green, color.Blue);
        }

        /// <summary>
        /// Restores keyboard illumination configuration
        /// </summary>
        public void RestoreLedRgb()
        {
            _restore_LED_RGB(RoccatHandle);
        }
    }
}
