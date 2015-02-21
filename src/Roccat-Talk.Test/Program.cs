using System;
using Roccat_Talk.RyosTalkFX;
using Roccat_Talk.RyosTalkFX.KeyboardLayouts;
using Roccat_Talk.TalkFX;

namespace RoccatTalk.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            TalkFxTEst();
            RyosTest();
        }

        private static void TalkFxTEst()
        {
            WriteAndWaitForEnter("TalkFX test, press enter to begin");

            using (var connection = new TalkFxConnection())
            {
                connection.SetLedRgb(Zone.Event, KeyEffect.Blinking, Speed.Normal, new Color(255, 105, 180));
                WriteAndWaitForEnter("The keys should now be blinking in a fairly pink color, press enter to continue");

                connection.SetLedRgb(Zone.Event, KeyEffect.On, Speed.Normal, new Color(255, 255, 255));
                WriteAndWaitForEnter("The keys should now be ON and have a white color, press enter to continue");

                connection.SetLedRgb(Zone.Event, KeyEffect.On, Speed.Normal, new Color(0, 0, 0));
                WriteAndWaitForEnter("The keys should now be OFF, press enter to continue");

                connection.SetLedRgb(Zone.Event, KeyEffect.Breathing, Speed.Normal, new Color(255, 0, 0));
                WriteAndWaitForEnter("The keys should now be 'breathing' in a red color, press enter to continue");

                connection.RestoreLedRgb();
            }

            WriteAndWaitForEnter("TalkFX test now finished, press enter to continue");
        }

        private static void RyosTest()
        {
            WriteAndWaitForEnter("RyosTalkFX test, press enter to begin");

            using (var connection = new RyosTalkFXConnection())
            {
                if (connection.Initialize())
                    Console.WriteLine("RyosTalkFX connection initialized...");
                else
                {
                    WriteAndWaitForEnter("RyosTalkFX connection could not be initialized, is the keyboard properly connected? Press enter to exit");
                    return;
                }

                if (connection.EnterSdkMode())
                    Console.WriteLine("Gained control over the keyboard...");
                else
                {
                    WriteAndWaitForEnter("Could not gain control over the keyboard, is another program using it? Press enter to exit");
                    return;
                }

                connection.TurnOffAllLights();
                WriteAndWaitForEnter("All keys should now be OFF, press enter to continue");

                connection.SetLedOn(KeyboardLayout_EN.A);
                WriteAndWaitForEnter("The 'A' key should now be ON, press enter to continue");

                var keyboardState = new KeyboardState();
                keyboardState.AllLedsOn();
                connection.SetWholeKeyboardState(keyboardState);
                WriteAndWaitForEnter("All keys should now be ON, press enter to continue");

                connection.SetLedOff(KeyboardLayout_EN.B);
                WriteAndWaitForEnter("The 'B' key should be OFF, press enter to continue");

                connection.BlinkAllKeys(1, 10);
                WriteAndWaitForEnter("All keys should now be blinking, press enter to continue");

                if (connection.ExitSdkMode())
                    Console.WriteLine("Released control of the keyboard...");
                else
                    Console.WriteLine("Could not release control of the keyboard!");

                WriteAndWaitForEnter("RyosTalkFX test now finished, press enter to continue");
            }
        }

        private static void WriteAndWaitForEnter(string message)
        {
            Console.WriteLine(message);
            Console.ReadLine();
        }
    }
}
