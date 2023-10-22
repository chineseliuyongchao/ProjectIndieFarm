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
        public static ResController Instance => MonoSingletonProperty<ResController>.Instance;

        void Start()
        {
            // Code Here
        }

        public void OnSingletonInit()
        {
        }
    }
}