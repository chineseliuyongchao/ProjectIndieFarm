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
            for (int i = 0; i < Global.ActiveChallenges.Count; i++)
            {
                var challenge = Global.ActiveChallenges[i];
                GUI.Label(new Rect(960 - 200, 20 + i * 20, 300, 30), challenge.Name);
            }

            for (int i = 0; i < Global.FinishChallenges.Count; i++)
            {
                var challenge = Global.FinishChallenges[i];
                GUI.Label(new Rect(960 - 200, 20 + (i + Global.ActiveChallenges.Count) * 20, 300, 30),
                    "<color=green>" + challenge.Name + "</color>");
            }
        }
    }
}