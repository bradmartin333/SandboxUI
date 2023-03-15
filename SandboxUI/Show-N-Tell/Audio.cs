using NAudio.Wave;
using System.Diagnostics;

namespace Show_N_Tell
{
    internal class Audio : IDisposable
    {
        internal int MaxBars = 75;
        internal int Bars { get; set; } = 0;

        private WaveInEvent? WaveIn = null;

        internal Audio()
        {
            WaveIn = new WaveInEvent
            {
                DeviceNumber = 0,
                WaveFormat = new WaveFormat(rate: 44100, bits: 16, channels: 1),
                BufferMilliseconds = 50
            };
            WaveIn.DataAvailable += WaveIn_DataAvailable;
            WaveIn.StartRecording();
        }

        private void WaveIn_DataAvailable(object? sender, WaveInEventArgs e)
        {
            float maxValue = 32767;
            int peakValue = 0;
            int bytesPerSample = 2;
            for (int index = 0; index < e.BytesRecorded; index += bytesPerSample)
            {
                int value = BitConverter.ToInt16(e.Buffer, index);
                peakValue = Math.Max(peakValue, value);
            }
            Bars = (int)Math.Pow(peakValue / maxValue * MaxBars, 2) / MaxBars;
            Debug.WriteLine($"{peakValue} {maxValue} {Bars}");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (WaveIn != null && disposing)
            {
                WaveIn.StopRecording();
                WaveIn.Dispose();
                WaveIn = null;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
