using QFramework;

namespace ProjectlndieFram
{
    public class Global
    {
        /// <summary>
        /// 记录天数，默认从第一天开始
        /// </summary>
        public static BindableProperty<int> Days = new BindableProperty<int>(1);
    }
}