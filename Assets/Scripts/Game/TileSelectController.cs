using QFramework;

namespace ProjectlndieFram
{
    /// <summary>
    /// 选择地块
    /// </summary>
    public partial class TileSelectController : ViewController, ISingleton
    {
        public static TileSelectController Instance => MonoSingletonProperty<TileSelectController>.Instance;

        public void OnSingletonInit()
        {
        }
    }
}