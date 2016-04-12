using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateUI : MonoBehaviour {
	[SerializeField]
	private Text timerLabel;

	[SerializeField]
	private Text coinsLabel;

	// Use this for initialization
	void Start () {
	
	}

	private string FormatTime(float timeInSeconds)
	{
		return string.Format("{0}:{1:00}", Mathf.FloorToInt(timeInSeconds/60), Mathf.FloorToInt(timeInSeconds % 60));
	}
	
	// Update is called once per frame
	void Update () {
		timerLabel.text = "Time: " + FormatTime (GameManager.Instance.TimeRemaining);
		coinsLabel.text = "Coins:" + GameManager.Instance.NumCoins.ToString();
	}
}
