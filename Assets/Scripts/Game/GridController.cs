using QFramework;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace ProjectlndieFram
{
    /// <summary>
    /// 控制生成地图
    /// </summary>
    public partial class GridController : ViewController
    {
        private EasyGrid<SoilData> _mShowGrid = new(10, 10);

        public EasyGrid<SoilData> MShowGrid
        {
            get => _mShowGrid;
            set => _mShowGrid = value;
        }

        public TileBase tileBaseLand;

        void Start()
        {
            _mShowGrid[0, 0] = new SoilData();
            _mShowGrid[2, 3] = new SoilData();
            _mShowGrid.ForEach((x, y, data) =>
            {
                if (data != null)
                {
                    Tilemap.SetTile(new Vector3Int(x, y, 0), tileBaseLand);
                }
            });
        }
    }
}