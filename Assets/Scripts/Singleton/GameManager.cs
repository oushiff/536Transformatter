using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {

	private float _timeRemaining;

	public float TimeRemaining 
	{
		get { return _timeRemaining; }
		set { _timeRemaining = value; }
	}

	private int _numCoins;

	public int NumCoins {
		get { return _numCoins; }
		set { _numCoins = value; }
	}

    private float _timeConsumed;

    public float TimeConsumed
    {
        get { return _timeConsumed; }
        set { _timeConsumed = value; }
    }

    private int _coinsGot;

    public int CoinsGot
    {
        get { return _coinsGot; }
        set { _coinsGot = value; }
    }

	private float _health;

	public float Health
	{
		get { return _health; }
		set { _health = value; }
	}

	private string _status = "PlayerSnow";

	public string Status
	{
		get{ return _status; }
		set{ _status = value; }
	}

	private float maxTime = 180; // In seconds.

	private float maxHealth = 100; // The max health of the hero

	// Use this for initialization
	void Start () {
		TimeRemaining = maxTime;
		Health = maxHealth;
	}


	// Update is called once per frame
	void Update () {
		TimeRemaining -= Time.deltaTime;

		if (TimeRemaining <= 0) {
			RestartGame ();
		}
	}

	void FixedUpdate(){

		if (Status == "PlayerCloud") 
		{
			Debug.LogError("PlayerCloud Heath:" + Health);
			//Health -= CloudStateHeathMinusValue;
			Health -= 0.01f;
		}
	}


	public void RestartGame(){
		Application.LoadLevel (Application.loadedLevel);
		ResetPlayerProperty ();
	}
	public void ResetPlayerProperty(){
		TimeRemaining = maxTime;
		NumCoins = 0;
		Health = maxHealth;
		Status = "PlayerSnow";
	}
}
