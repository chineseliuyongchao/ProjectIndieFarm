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
        /// 水
        /// </summary>
        public GameObject waterPrefab;

        /// <summary>
        /// 植物
        /// </summary>
        public GameObject plantPrefab;

        /// <summary>
        /// 种子贴图
        /// </summary>
        public Sprite seedSprite;

        /// <summary>
        /// 发芽植物贴图
        /// </summary>
        public Sprite budSprite;

        /// <summary>
        /// 成熟植物贴图
        /// </summary>
        public Sprite ripeSprite;

        /// <summary>
        /// 收获后的植物
        /// </summary>
        public Sprite oldSprite;

        public static ResController Instance => MonoSingletonProperty<ResController>.Instance;

        public void OnSingletonInit()
        {
        }
    }
}