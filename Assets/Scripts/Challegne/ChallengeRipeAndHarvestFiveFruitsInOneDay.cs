namespace ProjectlndieFram
{
    /// <summary>
    /// 在同一天成熟并且收集五个果实
    /// </summary>
    public class ChallengeRipeAndHarvestFiveFruitsInOneDay : Challenge
    {
        public override string Name { get; } = "在同一天成熟并且收集五个果实";

        public override void OnStart()
        {
        }

        public override bool CheckFinish()
        {
            return Global.Days.Value > StartDate && Global.FruitCountOneDay.Value >= 5;
        }

        public override void OnFinish()
        {
        }
    }
}