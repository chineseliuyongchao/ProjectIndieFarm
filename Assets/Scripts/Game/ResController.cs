using QFramework;
using UnityEngine;

namespace ProjectlndieFram
{
    /// <summary>
    /// 控制资源加载
    /// </summary>
    public partial class ResController : ViewController, ISingleton
    {
        /// <summary>
        /// 种子
        /// </summary>
        public GameObject seedPrefab;

        /// <summary>
        /// 水
        /// </summary>
        public GameObject waterPrefab;

        /// <summary>
        /// 发芽的植物
        /// </summary>
        public GameObject smallPlantPrefab;

        /// <summary>
        /// 成熟的植物
        /// </summary>
        public GameObject ripePrefab;

        public static ResController Instance => MonoSingletonProperty<ResController>.Instance;

        public void OnSingletonInit()
        {
        }
    }
}