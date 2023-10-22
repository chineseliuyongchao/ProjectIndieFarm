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
            var cellPosition = grid.WorldToCell(transform.position);
            var gridData = grid.GetComponent<GridController>().MShowGrid;
            var tileWords = grid.CellToWorld(cellPosition);
            tileWords.x += grid.cellSize.x / 2;
            tileWords.y += grid.cellSize.y / 2;
            if (cellPosition.x < gridData.Width && cellPosition.x >= 0 && cellPosition.y < gridData.Height &&
                cellPosition.y >= 0) //选中地块
            {
                TileSelectController.Instance.Show();
                TileSelectController.Instance.Position(tileWords);
            }
            else
            {
                TileSelectController.Instance.Hide();
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (cellPosition.x < gridData.Width && cellPosition.x >= 0 && cellPosition.y < gridData.Height &&
                    cellPosition.y >= 0)
                {
                    if (gridData[cellPosition.x, cellPosition.y] == null) //翻地
                    {
                        tilemap.SetTile(cellPosition, grid.GetComponent<GridController>().tileBaseLand);
                        gridData[cellPosition.x, cellPosition.y] = new SoilData();
                    }
                    else if (!gridData[cellPosition.x, cellPosition.y].HasPlant) //播种
                    {
                        ResController.Instance.seedPrefab.Instantiate().Position(tileWords);
                        gridData[cellPosition.x, cellPosition.y].HasPlant = true;
                    }
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                if (cellPosition.x < gridData.Width && cellPosition.x >= 0 && cellPosition.y < gridData.Height &&
                    cellPosition.y >= 0)
                {
                    if (gridData[cellPosition.x, cellPosition.y] != null) //清空地块
                    {
                        tilemap.SetTile(cellPosition, null);
                        gridData[cellPosition.x, cellPosition.y] = null;
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (cellPosition.x < gridData.Width && cellPosition.x >= 0 && cellPosition.y < gridData.Height &&
                    cellPosition.y >= 0)
                {
                    if (gridData[cellPosition.x, cellPosition.y] != null &&
                        !gridData[cellPosition.x, cellPosition.y].Watered) //浇水
                    {
                        ResController.Instance.waterPrefab.Instantiate().Position(tileWords);
                        gridData[cellPosition.x, cellPosition.y].Watered = true;
                    }
                }
            }
        }
    }
}