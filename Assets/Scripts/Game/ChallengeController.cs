using QFramework;
using UnityEngine;

namespace ProjectlndieFram
{
    public partial class ChallengeController : ViewController
    {
        private void OnGUI()
        {
            IMGUIHelper.SetDesignResolution(960, 540);

            GUI.Label(new Rect(960 - 200, 0, 300, 30), "挑战");
            for (int i = 0; i < Global.Challenges.Count; i++)
            {
                var challenge = Global.Challenges[i];
                if (challenge.ChallengeStates == ChallengeStates.FINISHED)
                {
                    GUI.Label(new Rect(960 - 200, 20 + i * 20, 300, 30), "<color=green>" + challenge.Name + "</color>");
                }
                else
                {
                    GUI.Label(new Rect(960 - 200, 20 + i * 20, 300, 30), challenge.Name);
                }
            }
        }
    }
}