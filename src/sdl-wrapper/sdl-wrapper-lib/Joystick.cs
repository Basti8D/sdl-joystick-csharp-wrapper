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
        public enum SDLHat : byte
        {
            SDL_HAT_CENTERED = 0x00,
            SDL_HAT_UP = 0x01,
            SDL_HAT_RIGHT = 0x02,
            SDL_HAT_DOWN = 0x04,
            SDL_HAT_LEFT = 0x08,
            SDL_HAT_RIGHTUP = SDL_HAT_RIGHT | SDL_HAT_UP,
            SDL_HAT_RIGHTDOWN = SDL_HAT_RIGHT | SDL_HAT_DOWN,
            SDL_HAT_LEFTUP = SDL_HAT_LEFT | SDL_HAT_UP,
            SDL_HAT_LEFTDOWN = SDL_HAT_LEFT | SDL_HAT_DOWN 
        }

        private IntPtr pointer;
        private int NumButtons;
        private int NumAxis;
        private int NumHats;
        private int NumBalls;
        public List<Int16> Axes
        {
            get 
            {
                return GetJoystickAxes();
            }
            private set
            {
                Axes = value;
            }
        }
        public List<bool> Buttons
        {
            get
            {
                return GetJoystickButtons();
            }
        }
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
            joystick.GetJoystickInfo();
            return joystick;
        }

        public string GetJoystickName()
        {
            return CastPtrToString(Wrapper.SDL_GetJoystickName(pointer));
        }

        public Int16 GetJoysickAxis(int axis)
        {
            Wrapper.SDL_UpdateJoysticks();
            return Wrapper.SDL_GetJoystickAxis(pointer, axis);
        }

        public List<Int16> GetJoystickAxes()
        {
            Wrapper.SDL_UpdateJoysticks();
            List<Int16> axes = new List<Int16>();
            for (int i = 0; i < NumAxis; i++)
            {
                axes.Add(GetJoysickAxis(i));
            }
            return axes;
        }



        public bool GetJoysickButton(int button)
        {
            Wrapper.SDL_UpdateJoysticks();
            return Wrapper.SDL_GetJoystickButton(pointer, button);
        }

        public List<bool> GetJoystickButtons()
        {
            Wrapper.SDL_UpdateJoysticks();
            List<bool> buttons = new List<bool>();
            for (int i = 0; i < NumButtons; i++)
            {
                buttons.Add(GetJoysickButton(i));
            }
            return buttons;
        }
        public SDLHat GetJoysickHat(int hat)
        {
            Wrapper.SDL_UpdateJoysticks();
            return (SDLHat)Wrapper.SDL_GetJoystickHat(pointer, hat);
        }

        public List<SDLHat> GetJoystickHats()
        {
            Wrapper.SDL_UpdateJoysticks();
            List<SDLHat> hats = new List<SDLHat>();
            for (int i = 0; i < NumHats; i++)
            {
                hats.Add(GetJoysickHat(i));
            }
            return hats;
        }

        private void GetJoystickInfo()
        {
            NumButtons = Wrapper.SDL_GetNumJoystickButtons(pointer);
            NumBalls = Wrapper.SDL_GetNumJoystickBalls(pointer);
            NumHats = Wrapper.SDL_GetNumJoystickHats(pointer);
            NumAxis = Wrapper.SDL_GetNumJoystickAxes(pointer);
        }
    }
}
