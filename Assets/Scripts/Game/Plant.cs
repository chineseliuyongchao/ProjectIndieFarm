using QFramework;
using UnityEngine;

namespace ProjectlndieFram
{
    public partial class Plant : ViewController
    {
        private PlantStates _plantStates = PlantStates.None;

        /// <summary>
        /// 成熟的日期
        /// </summary>
        private int _ripeDay;

        public int RipeDay
        {
            get => _ripeDay;
            set => _ripeDay = value;
        }

        public PlantStates PlantStates
        {
            get => _plantStates;
            set
            {
                if (_plantStates != value)
                {
                    if (_plantStates == PlantStates.Bud && value == PlantStates.Ripe)
                    {
                        _ripeDay = Global.Days.Value;
                    }

                    _plantStates = value;
                    switch (value)
                    {
                        case PlantStates.Bud:
                            GetComponent<SpriteRenderer>().sprite = ResController.Instance.budSprite;
                            break;
                        case PlantStates.Ripe:
                            GetComponent<SpriteRenderer>().sprite = ResController.Instance.ripeSprite;
                            break;
                        case PlantStates.Seed:
                            GetComponent<SpriteRenderer>().sprite = ResController.Instance.seedSprite;
                            break;
                        case PlantStates.Old:
                            GetComponent<SpriteRenderer>().sprite = ResController.Instance.oldSprite;
                            break;
                    }

                    FindObjectOfType<GridController>().MShowGrid[xCell, yCell].PlantStates = value;
                }
            }
        }

        public int xCell;
        public int yCell;
    }
}