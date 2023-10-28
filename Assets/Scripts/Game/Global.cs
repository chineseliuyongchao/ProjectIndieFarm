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
        /// 结果数量
        /// </summary>
        public static BindableProperty<int> FruitCount = new(0);

        /// <summary>
        /// 当前工具
        /// </summary>
        public static BindableProperty<string> CurrentToolName = new("手");
    }
}