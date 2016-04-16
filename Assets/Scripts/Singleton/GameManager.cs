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

	private float maxTime = 60; // In seconds.

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


	public void RestartGame(){
		//Debug.LogError ("Reset");


		Application.LoadLevel (Application.loadedLevel);
		TimeRemaining = maxTime;
		NumCoins = 0;
		//Reset the health of the hero
		Health = maxHealth;

	}
}
