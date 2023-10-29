using System.Linq;
using QFramework;
using UnityEngine;
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
            Global.OnPlantHarvest.Register(plant =>
            {
                if (plant.RipeDay == Global.Days.Value) //当天有两个果子同时成熟并且收获就可以通关
                {
                    Global.RipeAndHarvestCountInCurrentDay.Value++;
                }
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            Global.OnChallengeFinish.Register(challenge =>
                {
                    Debug.Log("challengeFinish:  " + challenge.Name);
                    if (Global.Challenges.All(challenge => challenge.ChallengeStates == ChallengeStates.FINISHED))
                    {
                        ActionKit.Delay(1, () => { SceneManager.LoadScene("PassScene"); }).Start(this);
                    }
                })
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