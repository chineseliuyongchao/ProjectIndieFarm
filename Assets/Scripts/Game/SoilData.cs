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

        /// <summary>
        /// 是否发芽
        /// </summary>
        public bool BudState { get; set; }

        /// <summary>
        /// 是否成熟
        /// </summary>
        public bool RipeState { get; set; }
    }
}