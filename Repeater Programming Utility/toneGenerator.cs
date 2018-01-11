using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repeater_Programming_Utility
{
    class toneGenerator
    {
        /// <summary>
        /// starts a tone
        /// </summary>
        /// <param name="freq">Frequency of the tone to play in hertz</param>
        /// <param name="duration">Duration of tone in seconds</param>
        public void start(int freq, int duration)
        {
            var signalGenerator = new SignalGenerator()
            {
                Gain = 0.2,
                Frequency = freq,
                Type = SignalGeneratorType.Sin
            }.Take(TimeSpan.FromSeconds(duration));

            using (var wo = new WaveOutEvent())
            {
                wo.Init(signalGenerator);
                wo.Play();
                while (wo.PlaybackState == PlaybackState.Playing)
                {
                    System.Threading.Thread.Sleep(500);
                }
            }
        }

        public void start(int freq)
        {
            var signalGenerator = new SignalGenerator()
            {
                Gain = 0.2,
                Frequency = freq,
                Type = SignalGeneratorType.Sin
            };

            using (var wo = new WaveOutEvent())
            {
                wo.Init(signalGenerator);
                wo.Play();
                while (wo.PlaybackState == PlaybackState.Playing)
                {
                    System.Threading.Thread.Sleep(500);
                }
            }
        }
    }
}
