using System.IO;
using System.Media;
using System.Reflection;
using UpsAndDowns.BusinessLogic;

namespace UpsAndDowns.GameLogic
{
    internal class SoundLooper
    {
        internal bool Playing { get; private set; }

        private readonly SoundPlayer _player;

        public SoundLooper(string filename)
        {
            Assembly assem = Assembly.GetExecutingAssembly();
            Stream? resourceStream = assem.GetManifestResourceStream(filename);
            if (resourceStream == null)
                Logger.Log("Resource not found!", filename);

            _player = new SoundPlayer(resourceStream);
            _player.Load();
        }

        public void Play()
        {
            Playing = true;
            _player.PlayLooping();
        }

        public void Stop()
        {
            Playing = false;
            _player.Stop();
        }
    }
}
