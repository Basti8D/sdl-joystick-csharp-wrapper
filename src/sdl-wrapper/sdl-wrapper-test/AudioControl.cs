using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Events;
using NAudio.CoreAudioApi;

namespace sdl_wrapper_test
{
    public class AudioControl
    {
        public static async Task VolumeUp()
        {
            await Simulate.Events().Click(KeyCode.VolumeUp).Invoke();
        }

        public static async Task VolumeDown()
        {
            await Simulate.Events().Click(KeyCode.VolumeDown).Invoke();
        }

        public static void SetVolume(float volume)
        {
            using var deviceEnumerator = new MMDeviceEnumerator();

            var device = deviceEnumerator.GetDefaultAudioEndpoint(
                DataFlow.Render,
                Role.Multimedia);

            device.AudioEndpointVolume.MasterVolumeLevelScalar = volume;
        }

        public static async Task MediaPlayPause()
        {
            await Simulate.Events().Click(KeyCode.MediaPlayPause).Invoke();
        }
        public static async Task MediaStop()
        {
            await Simulate.Events().Click(KeyCode.MediaStop).Invoke();
        }
        public static async Task NextMedia()
        {
            await Simulate.Events().Click(KeyCode.MediaNextTrack).Invoke();
        }

        public static async Task PrevMedia()
        {
            await Simulate.Events().Click(KeyCode.MediaPreviousTrack).Invoke();
        }
    }
}
