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
        }
    }
}
