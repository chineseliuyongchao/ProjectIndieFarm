using System.Linq;
using QFramework;
using Unity.VisualScripting;
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

                var seeds = SceneManager.GetActiveScene().GetRootGameObjects()
                    .Where(o => o.name.StartsWith("Seed"));

                PlantController.Instance.Plants.ForEach((x, y, plant) =>
                {
                    if (plant)
                    {
                        if (plant.PlantStates == PlantStates.Seed)
                        {
                            if (soilDataS[x, y].Watered)
                            {
                                plant.PlantStates = PlantStates.Bud;
                            }
                        }
                        else if (plant.PlantStates == PlantStates.Bud)
                        {
                            if (soilDataS[x, y].Watered)
                            {
                                plant.PlantStates = PlantStates.Ripe;
                            }
                        }
                    }
                });

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
            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            GUILayout.Label("果子：" + Global.FruitCount.Value);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            GUILayout.Label("下一天：F");
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            GUILayout.Label("浇水：E");
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
                        var plantGameObj = ResController.Instance.plantPrefab.Instantiate().Position(tileWords);
                        var plant = plantGameObj.GetComponent<Plant>();
                        plant.xCell = cellPosition.x;
                        plant.yCell = cellPosition.y;
                        PlantController.Instance.Plants[cellPosition.x, cellPosition.y] = plant;
                        plant.PlantStates = PlantStates.Seed;
                        gridData[cellPosition.x, cellPosition.y].HasPlant = true;
                    }
                    else if (gridData[cellPosition.x, cellPosition.y].PlantStates == PlantStates.Ripe)
                    {
                        var plantGameObj = PlantController.Instance.Plants[cellPosition.x, cellPosition.y];
                        var plant = plantGameObj.GetComponent<Plant>();
                        plant.PlantStates = PlantStates.Old;
                        Global.FruitCount.Value++;
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
                        if (PlantController.Instance.Plants[cellPosition.x, cellPosition.y] != null)
                        {
                            PlantController.Instance.Plants[cellPosition.x, cellPosition.y].gameObject.DestroySelf();
                        }
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

            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("PassScene");
            }
        }
    }
}