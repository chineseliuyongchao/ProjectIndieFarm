using QFramework;

namespace ProjectlndieFram
{
    /// <summary>
    /// 在同一天成熟并且收集两个果实
    /// </summary>
    public class ChallengeRipeAndHarvestTwoFruitsInOneDay : Challenge
    {
        public override void OnStart()
        {
            Global.OnPlantHarvest.Register(plant =>
            {
                if (plant.RipeDay == Global.Days.Value) //当天有两个果子同时成熟并且收获就可以通关
                {
                    Global.RipeAndHarvestCountInCurrentDay.Value++;
                }
            }).AddToUnregisterList(this);
        }

        public override bool CheckFinish()
        {
            return Global.RipeAndHarvestCountInCurrentDay.Value >= 2;
        }

        public override void OnFinish()
        {
            this.UnRegisterAll();
        }
    }
}