using UnityEngine;
using System.Collections;

public class MelleState : IEnemyState {
	
	public void Execute(){

		Debug.Log ("I am MelleState");

	}

	public void Enter(Enemy enemy){

	}

	public void Exit(){

	}

	public void OnTriggerEnter(Collider2D other){


	}
}
