using Do_An;
using NAudio.Wave;
using SharpCompress.Compressors.LZMA;

namespace FrontEnd
{
    public static class SoundManager
    {
        private static IWavePlayer? outputDevice;
        private static AudioFileReader? audioFile;
        private static LoopStream? loopStream;
        private static bool isBgmPlaying = false;

        public static void PlayClickSound()
        {
            if (!SettingVariable.SoundEffectsEnabled) return;

            try
            {
                Task.Run(() =>
                {
                    using var audio = new AudioFileReader("Resources/click.wav");
                    using var player = new WaveOutEvent();
                    player.Init(audio);
                    player.Play();
                    Thread.Sleep((int)audio.TotalTime.TotalMilliseconds); // Wait for sound to finish
                });
            }
            catch
            {
                // Optionally log error
            }
        }

        public static void PlayBackgroundMusic()
        {
            if (!SettingVariable.BackgroundMusicEnabled || isBgmPlaying) return;

            try
            {
                audioFile = new AudioFileReader("Resources/bgm.wav")
                {
                    Volume = 0.5f // Optional: set volume
                };
                loopStream = new LoopStream(audioFile); // Wrap in LoopStream

                outputDevice = new WaveOutEvent();
                outputDevice.Init(loopStream);
                outputDevice.Play();

                isBgmPlaying = true;
            }
            catch
            {
                // Optionally log error
            }
        }

        public static void StopBackgroundMusic()
        {
            try
            {
                outputDevice?.Stop();
                outputDevice?.Dispose();
                outputDevice = null;

                loopStream?.Dispose();
                loopStream = null;

                audioFile?.Dispose();
                audioFile = null;

                isBgmPlaying = false;
            }
            catch
            {
                // Optionally log error
            }
        }
    }
}
