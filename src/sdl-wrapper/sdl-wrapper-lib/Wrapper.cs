using sdl_wrapper_lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        [DllImport(DLL_FILE_NAME, CallingConvention = CallingConvention.Cdecl)]
        public extern static void SDL_JoystickClose(IntPtr joystick);
        [DllImport(DLL_FILE_NAME, CallingConvention = CallingConvention.Cdecl)]
        public extern static int SDL_GetNumJoystickButtons(IntPtr joystick);
        [DllImport(DLL_FILE_NAME, CallingConvention = CallingConvention.Cdecl)]
        public extern static bool SDL_GetJoystickButton(IntPtr joystick, int button);
        // Ball Implementation not Planned yet
        [DllImport(DLL_FILE_NAME, CallingConvention = CallingConvention.Cdecl)]
        public extern static int SDL_GetNumJoystickBalls(IntPtr joystick);
        [DllImport(DLL_FILE_NAME, CallingConvention = CallingConvention.Cdecl)]
        public extern static bool SDL_GetJoystickBall(IntPtr joystick, int ball, out int dx, out int dy);
        [DllImport(DLL_FILE_NAME, CallingConvention = CallingConvention.Cdecl)]
        public extern static int SDL_GetNumJoystickHats(IntPtr joystick);
        [DllImport(DLL_FILE_NAME, CallingConvention = CallingConvention.Cdecl)]
        public extern static int SDL_GetNumJoystickAxes(IntPtr joystick);
        [DllImport(DLL_FILE_NAME, CallingConvention = CallingConvention.Cdecl)]
        public extern static byte SDL_GetJoystickHat(IntPtr joystick, int hat);
        [DllImport(DLL_FILE_NAME, CallingConvention = CallingConvention.Cdecl)]
        public extern static Int16 SDL_GetJoystickAxis(IntPtr joystick, int axis);
        [DllImport(DLL_FILE_NAME, CallingConvention = CallingConvention.Cdecl)]
        public extern static bool SDL_JoystickEventsEnabled();
        [DllImport(DLL_FILE_NAME, CallingConvention = CallingConvention.Cdecl)]
        public extern static void SDL_UpdateJoysticks();
        
    }
}
