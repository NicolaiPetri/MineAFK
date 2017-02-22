using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using WindowsInput;

namespace MineAFK
{
    class Program
    {
        static private Boolean AfkActive = false;
        static private InputSimulator input = new InputSimulator();
        static void Main(string[] args)
        {
            var running = true;
            HotKeyManager.RegisterHotKey(Keys.M, KeyModifiers.Alt);
            HotKeyManager.HotKeyPressed += new EventHandler<HotKeyEventArgs>(HotKeyManager_HotKeyPressed);
            var kbThread = new Thread(new ThreadStart(KeyboardThread));
            kbThread.Start();
            while (running)
            {
                Thread.Sleep(100);
            }
        }

        static void KeyboardThread()
        {
            while (true)
            {
                if (AfkActive)
                {
                    input.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_A);
                    Thread.Sleep(1000);
                    input.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_A);
                    //Thread.Sleep(3000);
                    //                   input.Mouse.MoveMouseBy(0, -50);
                    MoveMouseSlowlyY(-100, 500);
                    Thread.Sleep(3000);
                    MoveMouseSlowlyY(100, 500);
//                    input.Mouse.MoveMouseBy(0, 50);
                    Thread.Sleep(1000);
                    input.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_D);
                    Thread.Sleep(1000);
                    input.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_D);
                    MoveMouseSlowlyY(-100, 500);
                    Thread.Sleep(3000);
                    MoveMouseSlowlyY(100, 500);
                    Thread.Sleep(1000);
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
            //Console.WriteLine("Hit nicolai!");
        }
        static void MoveMouseSlowlyY(int pixels, int duration)
        {
            int moveStep = pixels < 0 ? -1 : 1;
            int moved = 0;
            while (moved < Math.Abs(pixels))
            {
                input.Mouse.MoveMouseBy(0, moveStep);
                moved += 1;
                Thread.Sleep(duration / Math.Abs(pixels));
            }
        }
        static void HotKeyManager_HotKeyPressed(object sender, HotKeyEventArgs e)
        {
            AfkActive = AfkActive == false;
            if (AfkActive)
            {
                input.Mouse.LeftButtonDown();

            } else
            {
                input.Mouse.LeftButtonUp();
            }
        }
        static void aMain(string[] args)
        {
      
            Console.WriteLine("Hej Magnus");
            while (true)
            {
                Thread.Sleep(100);
            }
            Console.ReadKey();
        }
    }
}
