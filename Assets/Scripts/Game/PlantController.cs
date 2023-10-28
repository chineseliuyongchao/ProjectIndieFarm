using QFramework;

namespace ProjectlndieFram
{
    /// <summary>
    /// 控制植物状态
    /// </summary>
    public partial class PlantController : ViewController, ISingleton
    {
        public static PlantController Instance => MonoSingletonProperty<PlantController>.Instance;
        public EasyGrid<Plant> Plants = new(10, 10);

        public void OnSingletonInit()
        {
        }
    }

    /// <summary>
    /// 植物的几种状态
    /// </summary>
    public enum PlantStates
    {
        /// <summary>
        /// 没有植物
        /// </summary>
        None,

        /// <summary>
        /// 播种
        /// </summary>
        Seed,

        /// <summary>
        /// 发芽
        /// </summary>
        Bud,

        /// <summary>
        /// 成熟
        /// </summary>
        Ripe,

        /// <summary>
        /// 收获后
        /// </summary>
        Old
    }
}