namespace ProjectlndieFram
{
    /// <summary>
    /// 获得第一个果实
    /// </summary>
    public class ChallengeHarvestFirstFruit : Challenge
    {
        public ChallengeHarvestFirstFruit()
        {
            Name = "ChallengeHarvestFirstFruit";
        }

        public override void OnStart()
        {
        }

        public override bool CheckFinish()
        {
            return Global.FruitCount.Value > 0;
        }

        public override void OnFinish()
        {
        }
    }
}