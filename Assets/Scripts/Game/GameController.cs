using System.Linq;
using QFramework;
using UnityEngine.SceneManagement;

namespace ProjectlndieFram
{
    /// <summary>
    /// 游戏控制类
    /// </summary>
    public partial class GameController : ViewController
    {
        private void Start()
        {
            Global.ActiveChallenges.Add(Global.Challenges.GetRandomItem());
            Global.OnChallengeFinish.Register(challenge =>
                {
                    if (Global.Challenges.All(c => c.ChallengeStates == ChallengeStates.FINISHED))
                    {
                        ActionKit.Delay(1, () => { SceneManager.LoadScene("PassScene"); }).Start(this);
                    }
                })
                .UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void Update()
        {
            bool hasFinish = false;
            foreach (var challenge in Global.ActiveChallenges)
            {
                //在这里进行挑战完成检测
                if (challenge.ChallengeStates == ChallengeStates.NO_START)
                {
                    challenge.StartDate = Global.Days.Value;
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
                        Global.FinishChallenges.Add(challenge);
                        hasFinish = true;
                    }
                }
            }

            if (hasFinish)
            {
                Global.ActiveChallenges.RemoveAll(c => c.ChallengeStates == ChallengeStates.FINISHED);
            }

            if (Global.ActiveChallenges.Count == 0 && Global.FinishChallenges.Count != Global.Challenges.Count)
            {
                Global.ActiveChallenges.Add(Global.Challenges
                    .Where(c => c.ChallengeStates == ChallengeStates.NO_START).ToList()
                    .GetRandomItem());
            }
        }
    }
}