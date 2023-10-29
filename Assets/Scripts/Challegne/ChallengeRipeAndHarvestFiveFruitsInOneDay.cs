namespace ProjectlndieFram
{
    /// <summary>
    /// 在同一天成熟并且收集两个果实
    /// </summary>
    public class ChallengeRipeAndHarvestFiveFruitsInOneDay : Challenge
    {
        public ChallengeRipeAndHarvestFiveFruitsInOneDay()
        {
            Name = "ChallengeRipeAndHarvestFiveFruitsInOneDay";
        }

        public override void OnStart()
        {
        }

        public override bool CheckFinish()
        {
            return Global.RipeAndHarvestCountInCurrentDay.Value >= 5;
        }

        public override void OnFinish()
        {
        }
    }
}