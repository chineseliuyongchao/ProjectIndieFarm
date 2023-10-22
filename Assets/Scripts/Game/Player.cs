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
                var gridData = grid.GetComponent<GridController>().MShowGrid;
                if (cellPosition.x < gridData.Width && cellPosition.x >= 0 && cellPosition.y < gridData.Height &&
                    cellPosition.y >= 0)
                {
                    if (gridData[cellPosition.x, cellPosition.y] == null)
                    {
                        tilemap.SetTile(cellPosition, grid.GetComponent<GridController>().tileBaseLand);
                        gridData[cellPosition.x, cellPosition.y] = new SoilData();
                    }
                    else if (!gridData[cellPosition.x, cellPosition.y].HasSeed)
                    {
                        var tileWords = grid.CellToWorld(cellPosition);
                        tileWords.x += grid.cellSize.x / 2;
                        tileWords.y += grid.cellSize.y / 2;
                        ResController.Instance.seedPrefab.Instantiate().Position(tileWords);
                        gridData[cellPosition.x, cellPosition.y].HasSeed = true;
                    }
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                var cellPosition = grid.WorldToCell(transform.position);
                var girdData = grid.GetComponent<GridController>().MShowGrid;
                if (cellPosition.x < girdData.Width && cellPosition.x >= 0 && cellPosition.y < girdData.Height &&
                    cellPosition.y >= 0)
                {
                    if (girdData[cellPosition.x, cellPosition.y] != null)
                    {
                        tilemap.SetTile(cellPosition, null);
                        girdData[cellPosition.x, cellPosition.y] = null;
                    }
                }
            }
        }
    }
}