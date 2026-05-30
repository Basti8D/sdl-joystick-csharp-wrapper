using sdl_wrapper_lib;

namespace sdl_wrapper_test
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<Joystick> joysticks;
            joysticks = new List<Joystick>();
            Joystick.InitJoystickSystem();
            int count = Joystick.GetJoystickCount();
            Console.WriteLine($"Count: {count}");
            for (uint i = 1; i <= count; i++)
            {
                joysticks.Add(Joystick.createJoystick(i));
            }
            foreach(Joystick joystick in joysticks)
            {
                Console.WriteLine(joystick.GetJoystickName());
            }
            bool events = Wrapper.SDL_JoystickEventsEnabled();
            if (events)
            {
                Console.WriteLine("Events Enabled");
            }

            Console.WriteLine(joysticks[0].Buttons.Count);

            int j = 0;

            while (true)
            {
                
                List<short> axes = joysticks[0].Axes;

                for (int i = 0; i < axes.Count; i++)
                {
                    Console.SetCursorPosition(0, i + 6);
                    Console.Write($"Axis {i}: {axes[i]}");
                }

                List<bool> buttons = joysticks[0].Buttons;
                j = 0;
                for (int i = 0; i < buttons.Count; i++)
                {
                    if (i > 0 && i % 10 == 0)
                    {
                        j++;
                    }
                    Console.SetCursorPosition(j * 18 + 16, i % 10 + 6);
                    Console.Write($"Button {i}: {buttons[i]}");
                }

                axes = joysticks[2].Axes;

                for (int i = 0; i < axes.Count; i++)
                {
                    Console.SetCursorPosition(0, i + 17);
                    Console.Write($"Axis {i}: {axes[i]}");
                }

                buttons = joysticks[2].Buttons;
                j = 0;
                for (int i = 0; i < buttons.Count; i++)
                {
                    if (i > 0 && i % 10 == 0)
                    {
                        j++;
                    }
                    Console.SetCursorPosition(j * 18 + 16, i % 10 + 17);
                    Console.Write($"Button {i}: {buttons[i]}");
                }

                j++;

                List<Joystick.SDLHat> hats = joysticks[2].GetJoystickHats();

                for (int i = 0; i < hats.Count; i++)
                {
                    if (i > 0 && i % 10 == 0)
                    {
                        j++;
                    }
                    Console.SetCursorPosition(j * 18 + 16, i % 10 + 17);
                    Console.Write($"Hat {i}: {hats[i]}");
                }

            }
        }
    }
}
