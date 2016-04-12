using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class UpdateWinScene : MonoBehaviour {

    [SerializeField]
    private Text timerLabel;

    [SerializeField]
    private Text coinsLabel;

    

    private string FormatTime(float timeInSeconds)
    {
        return string.Format("{0}:{1:00}", Mathf.FloorToInt(timeInSeconds / 60), Mathf.FloorToInt(timeInSeconds % 60));
    }

    // Use this for initialization
    
    void Start()
    {
        timerLabel.text = "Time: " + FormatTime(GameManager.Instance.TimeConsumed);
        coinsLabel.text = "Coins:" + GameManager.Instance.CoinsGot.ToString();
    }
}
