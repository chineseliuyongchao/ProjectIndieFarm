using QFramework;
using UnityEngine;

namespace ProjectlndieFram
{
    /// <summary>
    /// 控制资源加载
    /// </summary>
    public partial class ResController : ViewController, ISingleton
    {
        public GameObject seedPrefab;
        public GameObject waterPrefab;
        public GameObject smallPlantPrefab;
        public static ResController Instance => MonoSingletonProperty<ResController>.Instance;

        public void OnSingletonInit()
        {
        }
    }
}