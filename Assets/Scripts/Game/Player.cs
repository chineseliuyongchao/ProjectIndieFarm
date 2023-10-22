using QFramework;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace ProjectlndieFram
{
    /// <summary>
    /// 控制主角的类
    /// </summary>
    public partial class Player : ViewController
    {
        public Grid grid;
        public Tilemap tilemap;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var cellPosition = grid.WorldToCell(transform.position);
                var girdData = grid.GetComponent<GridController>().MShowGrid;
                if (cellPosition.x < girdData.Width && cellPosition.x > 0 && cellPosition.y < girdData.Height &&
                    cellPosition.y > 0)
                {
                    if (girdData[cellPosition.x, cellPosition.y] == null)
                    {
                        tilemap.SetTile(cellPosition, grid.GetComponent<GridController>().tileBaseLand);
                        girdData[cellPosition.x, cellPosition.y] = new SoilData();
                    }
                }
            }
        }
    }
}