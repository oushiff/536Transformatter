﻿using UnityEngine;
using System.Collections;

public class RangedState : IEnemyState {

	private Enemy enemy;

	public void Execute(){

		Debug.Log ("I am ranged state");

		if (enemy.target != null) {
			enemy.Move ();
		} else
			enemy.ChangeState (new IdleState ());

	}

	public void Enter(Enemy enemy){
		this.enemy = enemy;
	}

	public void Exit(){

	}

	public void OnTriggerEnter(Collider2D other){


	}

}
