namespace ProjectlndieFram
{
    /// <summary>
    /// 获得一个果实
    /// </summary>
    public class ChallengeHarvestOneFruit : Challenge
    {
        public override string Name { get; } = "获得一个果实";

        public override void OnStart()
        {
        }

        public override bool CheckFinish()
        {
            return Global.Days.Value > StartDate && Global.FruitCountOneDay.Value > 0;
        }

        public override void OnFinish()
        {
        }
    }
}