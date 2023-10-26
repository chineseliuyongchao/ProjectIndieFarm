namespace ProjectlndieFram
{
    public class SoilData
    {
        /// <summary>
        /// 是否有植物
        /// </summary>
        public bool HasPlant { get; set; }

        /// <summary>
        /// 是否浇水
        /// </summary>
        public bool Watered { get; set; }

        public PlantStates PlantStates { get; set; } = PlantStates.None;
    }
}