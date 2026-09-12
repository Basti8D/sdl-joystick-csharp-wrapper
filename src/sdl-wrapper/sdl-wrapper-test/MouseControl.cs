using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WindowsInput;
using WindowsInput.Events;

namespace sdl_wrapper_test
{
    public class MouseControl
    {
        public MouseControl() { }

        public static async Task LeftClick()
        {
            await Simulate.Events().Click(ButtonCode.Left).Invoke();
        }

        public static async Task LeftClick(int ms)
        {
            await Simulate.Events().Hold(ButtonCode.Left).Wait(ms).Release(ButtonCode.Left).Invoke();
        }

        public static async Task RightClick()
        {
            await Simulate.Events().Click(ButtonCode.Right).Invoke();
        }

        public static async Task RightClick(int ms)
        {
            await Simulate.Events().Hold(ButtonCode.Right).Wait(ms).Release(ButtonCode.Right).Invoke();
        }
        public static async Task RelativeMove (int x, int y)
        {
            await Simulate.Events().MoveBy(x, y).Invoke();
        }

        public static async Task AbsoluteMove(int x, int y)
        {
            await Simulate.Events().MoveTo(x, y).Invoke();
        }
    }
}