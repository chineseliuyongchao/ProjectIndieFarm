namespace ProjectlndieFram
{
    /// <summary>
    /// 在同一天成熟并且收集两个果实
    /// </summary>
    public class ChallengeRipeAndHarvestTwoFruitsInOneDay : Challenge
    {
        public override string Name { get; } = "在同一天成熟并且收集两个果实";

        public override void OnStart()
        {
        }

        public override bool CheckFinish()
        {
            return Global.RipeAndHarvestCountInCurrentDay.Value >= 2;
        }

        public override void OnFinish()
        {
        }
    }
}