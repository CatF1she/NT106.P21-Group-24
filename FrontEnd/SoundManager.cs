using Do_An;
using NAudio.Wave;

namespace FrontEnd
{
    public static class SoundManager
    {
        private static IWavePlayer? outputDevice;
        private static AudioFileReader? audioFile;
        private static bool isBgmPlaying = false;

        private static WaveOutEvent? clickPlayer;

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
                    Thread.Sleep((int)audio.TotalTime.TotalMilliseconds); // wait until sound finishes
                });
            }
            catch { }
        }


        public static void PlayBackgroundMusic()
        {
            if (!SettingVariable.BackgroundMusicEnabled || isBgmPlaying) return;

            try
            {
                audioFile = new AudioFileReader("Resources/bgm.wav");
                outputDevice = new WaveOutEvent();
                outputDevice.Init(audioFile);
                outputDevice.Play();
                isBgmPlaying = true;
            }
            catch { }
        }

        public static void StopBackgroundMusic()
        {
            try
            {
                outputDevice?.Stop();
                outputDevice?.Dispose();
                audioFile?.Dispose();
                outputDevice = null;
                audioFile = null;
                isBgmPlaying = false;
            }
            catch { }
        }
    }
}
