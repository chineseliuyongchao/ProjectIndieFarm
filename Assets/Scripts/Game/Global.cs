using System.Collections.Generic;
using QFramework;

namespace ProjectlndieFram
{
    public class Global
    {
        /// <summary>
        /// 记录天数，默认从第一天开始
        /// </summary>
        public static BindableProperty<int> Days = new(1);

        /// <summary>
        /// 收获果实数量
        /// </summary>
        public static BindableProperty<int> FruitCount = new(0);

        /// <summary>
        /// 一天收获果实数量
        /// </summary>
        public static BindableProperty<int> FruitCountOneDay = new(0);

        /// <summary>
        /// 当前工具
        /// </summary>
        public static BindableProperty<string> CurrentTool = new(Constant.TOOL_HAND);

        /// <summary>
        /// 存放所有挑战
        /// </summary>
        public static List<Challenge> Challenges = new()
        {
            new ChallengeHarvestOneFruit(),
            new ChallengeRipeAndHarvestTwoFruitsInOneDay(),
            new ChallengeRipeAndHarvestFiveFruitsInOneDay()
        };

        /// <summary>
        /// 存放所有激活挑战
        /// </summary>
        public static List<Challenge> ActiveChallenges = new();

        /// <summary>
        /// 存放所有完成挑战
        /// </summary>
        public static List<Challenge> FinishChallenges = new();

        /// <summary>
        /// 收割植物的事件
        /// </summary>
        public static EasyEvent<Plant> OnPlantHarvest = new();

        /// <summary>
        /// 挑战完成的事件
        /// </summary>
        public static EasyEvent<Challenge> OnChallengeFinish = new();
    }

    public class Constant
    {
        /// <summary>
        /// 工具常量手
        /// </summary>
        public const string TOOL_HAND = "toolHand";

        /// <summary>
        /// 工具常量锄头
        /// </summary>
        public const string TOOL_SHOVEL = "toolShovel";

        /// <summary>
        /// 工具常量种子
        /// </summary>
        public const string TOOL_SEED = "toolSeed";

        /// <summary>
        /// 工具常量水桶
        /// </summary>
        public const string TOOL_BUCKET = "toolBucket";

        public static string DisplayName(string tool)
        {
            switch (tool)
            {
                case TOOL_HAND:
                    return "手";
                case TOOL_SHOVEL:
                    return "锄头";
                case TOOL_SEED:
                    return "种子";
                case TOOL_BUCKET:
                    return "水桶";
            }

            return "";
        }
    }
}