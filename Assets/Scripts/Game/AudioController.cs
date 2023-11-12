using QFramework;

namespace ProjectlndieFram
{
    public partial class AudioController : ViewController, ISingleton
    {
        public static AudioController Singlention => MonoSingletonProperty<AudioController>.Instance;

        public void OnSingletonInit()
        {
        }
    }
}