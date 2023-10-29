using System.Linq;
using QFramework;
using UnityEngine;

namespace ProjectlndieFram
{
    /// <summary>
    /// 游戏控制类
    /// </summary>
    public partial class GameController : ViewController
    {
        private void Start()
        {
            Global.OnChallengeFinish.Register(challenge => { Debug.Log("challengeFinish:  " + challenge.Name); })
                .UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void Update()
        {
            foreach (var challenge in Global.Challenges.Where(challenge =>
                         challenge.ChallengeStates != ChallengeStates.FINISHED))
            {
                if (challenge.ChallengeStates == ChallengeStates.NO_START)
                {
                    challenge.OnStart();
                    challenge.ChallengeStates = ChallengeStates.STARTED;
                }
                else if (challenge.ChallengeStates == ChallengeStates.STARTED)
                {
                    if (challenge.CheckFinish())
                    {
                        challenge.OnFinish();
                        challenge.ChallengeStates = ChallengeStates.FINISHED;
                        Global.OnChallengeFinish.Trigger(challenge);
                    }
                }
            }
        }
    }
}