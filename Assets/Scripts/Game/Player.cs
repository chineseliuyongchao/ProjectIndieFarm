using System.Linq;
using QFramework;
using UnityEngine;
using UnityEngine.SceneManagement;
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

        private void Start()
        {
            Global.Days.Register(day =>
            {
                var soilDataS = grid.GetComponent<GridController>().MShowGrid;

                var smallPlants = SceneManager.GetActiveScene().GetRootGameObjects()
                    .Where(o => o.name.StartsWith("SmallPlant"));
                foreach (var smallPlant in smallPlants)
                {
                    var cellPosition = grid.WorldToCell(smallPlant.transform.position);
                    var soilData = grid.GetComponent<GridController>().MShowGrid[cellPosition.x, cellPosition.y];
                    if (soilData != null && soilData.Watered && soilData.BudState)
                    {
                        //发芽并且浇水以后才能成熟
                        ResController.Instance.ripePrefab.Instantiate().Position(smallPlant.transform.position);
                        smallPlant.DestroySelf();
                        soilData.BudState = false;
                        soilData.RipeState = true;
                    }
                }

                var seeds = SceneManager.GetActiveScene().GetRootGameObjects()
                    .Where(o => o.name.StartsWith("Seed"));
                foreach (var seed in seeds)
                {
                    var cellPosition = grid.WorldToCell(seed.transform.position);
                    var soilData = grid.GetComponent<GridController>().MShowGrid[cellPosition.x, cellPosition.y];
                    if (soilData != null && soilData.Watered && soilData.HasPlant)
                    {
                        //播种并且浇水以后才能发芽
                        ResController.Instance.smallPlantPrefab.Instantiate().Position(seed.transform.position);
                        seed.DestroySelf();
                        soilData.BudState = true;
                    }
                }

                //每过一天把前一天浇水的状态清空
                soilDataS.ForEach(data =>
                {
                    if (data != null)
                    {
                        data.Watered = false;
                    }
                });
                foreach (var water in SceneManager.GetActiveScene().GetRootGameObjects()
                             .Where(o => o.name.StartsWith("Water")))
                {
                    water.DestroySelf();
                }
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void OnGUI()
        {
            IMGUIHelper.SetDesignResolution(640, 360);
            GUILayout.Space(10);
            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            GUILayout.Label("天数：" + Global.Days.Value);
            GUILayout.EndHorizontal();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Global.Days.Value++;
            }

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