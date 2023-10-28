using UnityEngine;
using QFramework;
using UnityEngine.SceneManagement;

namespace ProjectlndieFram
{
	public partial class GameRestartController : ViewController
	{
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				SceneManager.LoadScene("MainScene");
			}
		}
	}
}
