using NAudio.Wave;

namespace Show_N_Tell.Tools
{
    internal class Audio : IDisposable
    {
        float MaxValue = 1;
        internal int MaxBars = 100;
        internal int Bars { get; set; } = 0;

        private WaveInEvent? WaveIn = null;
        private static bool Calibrating = false;

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

        internal void BeginCalibration()
        {
            Calibrating = true;
            while (Calibrating)
            {
                int thisNumBars = Bars;
                if (thisNumBars > MaxBars)
                    MaxBars = thisNumBars;
                Console.ForegroundColor = (ConsoleColor)Math.Clamp(15 - thisNumBars, 1, 15);
                for (int i = 0; i < thisNumBars; i++)
                    Console.Write("|");
                Console.WriteLine();
                Thread.Sleep(10);
            }
        }

        internal void EndCalibration()
        {
            Calibrating = false;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"\nWe got to a max value of {MaxValue}!");
            Console.WriteLine($"That is {MaxValue / 32767:P} of the theoretical max");
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private void WaveIn_DataAvailable(object? sender, WaveInEventArgs e)
        {
            int peakValue = 0;
            int bytesPerSample = 2;
            for (int index = 0; index < e.BytesRecorded; index += bytesPerSample)
            {
                int value = BitConverter.ToInt16(e.Buffer, index);
                peakValue = Math.Max(peakValue, value);
                if (peakValue > MaxValue) MaxValue = peakValue;
            }
            Bars = (int)Math.Pow(peakValue / MaxValue * MaxBars, 2) / MaxBars;
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
