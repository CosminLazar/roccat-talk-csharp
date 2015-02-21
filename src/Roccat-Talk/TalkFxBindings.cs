using System;
using System.Runtime.InteropServices;

namespace Roccat_Talk
{
    internal static class TalkFxBindings
    {
        [DllImport("CroccatTalkWrapper\\win32-x86\\talkfx-c.dll", EntryPoint = "newRoccatTalkHandle", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr newRoccatTalkHandle_x86();

        [DllImport("CroccatTalkWrapper\\win32-x86-64\\talkfx-c.dll", EntryPoint = "newRoccatTalkHandle", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr newRoccatTalkHandle_x64();


        [DllImport("CroccatTalkWrapper\\win32-x86\\talkfx-c.dll", EntryPoint = "destroyRoccatTalkHandle", CallingConvention = CallingConvention.Cdecl)]
        public static extern void destroyRoccatTalkHandle_x86(IntPtr handle);

        [DllImport("CroccatTalkWrapper\\win32-x86-64\\talkfx-c.dll", EntryPoint = "destroyRoccatTalkHandle", CallingConvention = CallingConvention.Cdecl)]
        public static extern void destroyRoccatTalkHandle_x64(IntPtr handle);


        internal static class TalkFX
        {
            [DllImport("CroccatTalkWrapper\\win32-x86\\talkfx-c.dll", EntryPoint = "Set_LED_RGB", CallingConvention = CallingConvention.Cdecl)]
            public static extern void Set_LED_RGB_x86(IntPtr handle, byte bZone, byte bEffect, byte bSpeed, byte colorR, byte colorG, byte colorB);

            [DllImport("CroccatTalkWrapper\\win32-x86-64\\talkfx-c.dll", EntryPoint = "Set_LED_RGB", CallingConvention = CallingConvention.Cdecl)]
            public static extern void Set_LED_RGB_x64(IntPtr handle, byte bZone, byte bEffect, byte bSpeed, byte colorR, byte colorG, byte colorB);


            /* TALK FX method -- restore user LED colour at end of program */
            [DllImport("CroccatTalkWrapper\\win32-x86\\talkfx-c.dll", EntryPoint = "RestoreLEDRGB", CallingConvention = CallingConvention.Cdecl)]
            public static extern void RestoreLEDRGB_x86(IntPtr handle);

            [DllImport("CroccatTalkWrapper\\win32-x86-64\\talkfx-c.dll", EntryPoint = "RestoreLEDRGB", CallingConvention = CallingConvention.Cdecl)]
            public static extern void RestoreLEDRGB_x64(IntPtr handle);
        }

        internal static class RyosMKPRO
        {
            //Ryos MK PRO METHODS
            /* initiate connection to Ryos MK PRO keyboard and check if present */
            [DllImport("CroccatTalkWrapper\\win32-x86\\talkfx-c.dll", EntryPoint = "init_ryos_talk", CallingConvention = CallingConvention.Cdecl)]
            public static extern bool init_ryos_talk_x86(IntPtr handle);

            [DllImport("CroccatTalkWrapper\\win32-x86-64\\talkfx-c.dll", EntryPoint = "init_ryos_talk", CallingConvention = CallingConvention.Cdecl)]
            public static extern bool init_ryos_talk_x64(IntPtr handle);


            /* take control of a connected Ryos MK PRO keyboard */
            [DllImport("CroccatTalkWrapper\\win32-x86\\talkfx-c.dll", EntryPoint = "set_ryos_kb_SDKmode", CallingConvention = CallingConvention.Cdecl)]
            public static extern bool set_ryos_kb_SDKmode_x86(IntPtr handle, bool state);

            [DllImport("CroccatTalkWrapper\\win32-x86-64\\talkfx-c.dll", EntryPoint = "set_ryos_kb_SDKmode", CallingConvention = CallingConvention.Cdecl)]
            public static extern bool set_ryos_kb_SDKmode_x64(IntPtr handle, bool state);


            /* basic Ryos MK PRO LED control methods */
            [DllImport("CroccatTalkWrapper\\win32-x86\\talkfx-c.dll", EntryPoint = "turn_off_all_LEDS", CallingConvention = CallingConvention.Cdecl)]
            public static extern void turn_off_all_LEDS_x86(IntPtr handle);

            [DllImport("CroccatTalkWrapper\\win32-x86-64\\talkfx-c.dll", EntryPoint = "turn_off_all_LEDS", CallingConvention = CallingConvention.Cdecl)]
            public static extern void turn_off_all_LEDS_x64(IntPtr handle);


            [DllImport("CroccatTalkWrapper\\win32-x86\\talkfx-c.dll", EntryPoint = "turn_on_all_LEDS", CallingConvention = CallingConvention.Cdecl)]
            public static extern void turn_on_all_LEDS_x86(IntPtr handle);

            [DllImport("CroccatTalkWrapper\\win32-x86-64\\talkfx-c.dll", EntryPoint = "turn_on_all_LEDS", CallingConvention = CallingConvention.Cdecl)]
            public static extern void turn_on_all_LEDS_x64(IntPtr handle);


            /* turn on/off a single LED at specified position */
            [DllImport("CroccatTalkWrapper\\win32-x86\\talkfx-c.dll", EntryPoint = "set_LED_on", CallingConvention = CallingConvention.Cdecl)]
            public static extern void set_LED_on_x86(IntPtr handle, byte ucPos);

            [DllImport("CroccatTalkWrapper\\win32-x86-64\\talkfx-c.dll", EntryPoint = "set_LED_on", CallingConvention = CallingConvention.Cdecl)]
            public static extern void set_LED_on_x64(IntPtr handle, byte ucPos);


            [DllImport("CroccatTalkWrapper\\win32-x86\\talkfx-c.dll", EntryPoint = "set_LED_off", CallingConvention = CallingConvention.Cdecl)]
            public static extern void set_LED_off_x86(IntPtr handle, byte ucPos);

            [DllImport("CroccatTalkWrapper\\win32-x86-64\\talkfx-c.dll", EntryPoint = "set_LED_off", CallingConvention = CallingConvention.Cdecl)]
            public static extern void set_LED_off_x64(IntPtr handle, byte ucPos);


            /* send a whole array as a frame to the keyboard (manipulate mulitple LEDS)*/
            [DllImport("CroccatTalkWrapper\\win32-x86\\talkfx-c.dll", EntryPoint = "Set_all_LEDS", CallingConvention = CallingConvention.Cdecl)]
            public static extern void Set_all_LEDS_x86(IntPtr handle, byte[] ucLED);

            [DllImport("CroccatTalkWrapper\\win32-x86-64\\talkfx-c.dll", EntryPoint = "Set_all_LEDS", CallingConvention = CallingConvention.Cdecl)]
            public static extern void Set_all_LEDS_x64(IntPtr handle, byte[] ucLED);


            /* simple blinking effect on Ryos MK PRO */
            [DllImport("CroccatTalkWrapper\\win32-x86\\talkfx-c.dll", EntryPoint = "All_Key_Blinking", CallingConvention = CallingConvention.Cdecl)]
            public static extern void All_Key_Blinking_x86(IntPtr handle, int DelayTime, int LoopTimes);

            [DllImport("CroccatTalkWrapper\\win32-x86-64\\talkfx-c.dll", EntryPoint = "All_Key_Blinking", CallingConvention = CallingConvention.Cdecl)]
            public static extern void All_Key_Blinking_x64(IntPtr handle, int DelayTime, int LoopTimes);
        }
    }
}