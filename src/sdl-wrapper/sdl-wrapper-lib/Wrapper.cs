using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace sdl_wrapper_lib
{
    public class Wrapper
    {
        private const string DLL_FILE_NAME = "SDL3.dll";

        public static uint SDL_INIT_JOYSTICK = 0x00000200u;

        [DllImport(DLL_FILE_NAME, CallingConvention = CallingConvention.Cdecl)]
        public extern static int SDL_Init(uint Flags);

        [DllImport(DLL_FILE_NAME, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr SDL_GetJoysticks(out int count);

        [DllImport(DLL_FILE_NAME, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr SDL_OpenJoystick(uint joystick);

        [DllImport(DLL_FILE_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_CloseJoystick(IntPtr joystick);
        [DllImport(DLL_FILE_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetJoystickName(IntPtr joystick);

    }
}
