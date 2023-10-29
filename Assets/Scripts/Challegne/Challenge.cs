using System.Collections.Generic;
using QFramework;

namespace ProjectlndieFram
{
    /// <summary>
    /// 挑战基类
    /// </summary>
    public abstract class Challenge : IUnRegisterList
    {
        private ChallengeStates _challengeStates = ChallengeStates.NO_START;

        public ChallengeStates ChallengeStates
        {
            get => _challengeStates;
            set => _challengeStates = value;
        }

        /// <summary>
        /// 记录挑战开始的时间，确保挑战最早在开始第二天才能完成
        /// </summary>
        private int _startDate;

        public int StartDate
        {
            get => _startDate;
            set => _startDate = value;
        }

        /// <summary>
        /// 挑战的名字
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// 开始挑战
        /// </summary>
        public abstract void OnStart();

        /// <summary>
        /// 判断挑战是否完成
        /// </summary>
        /// <returns></returns>
        public abstract bool CheckFinish();

        /// <summary>
        /// 挑战完成
        /// </summary>
        public abstract void OnFinish();

        public List<IUnRegister> UnregisterList { get; } = new();
    }

    public enum ChallengeStates
    {
        NO_START,
        STARTED,
        FINISHED
    }
}