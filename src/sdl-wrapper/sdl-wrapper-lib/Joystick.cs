using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace sdl_wrapper_lib
{
    public class Joystick
    {
        private IntPtr pointer;

        private static string CastPtrToString(IntPtr ptr)
        {
            return Marshal.PtrToStringAnsi(ptr);
        }

        private Joystick(IntPtr pointer) 
        { 
            this.pointer = pointer;
        }

        public static void InitJoystickSystem()
        {
            Wrapper.SDL_Init(Wrapper.SDL_INIT_JOYSTICK);
        }

        public static int GetJoystickCount()
        {
            Wrapper.SDL_GetJoysticks(out int count);
            return count;
        }
        
        public static Joystick createJoystick(uint id)
        {
            Joystick joystick = new Joystick(Wrapper.SDL_OpenJoystick(id));
            return joystick;
        }

        public string GetJoystickName()
        {
            return CastPtrToString(Wrapper.SDL_GetJoystickName(pointer));
        }
    }
}
