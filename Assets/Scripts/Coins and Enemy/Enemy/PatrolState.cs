using UnityEngine;
using System.Collections;

public class PatrolState : IEnemyState {

	private Enemy enemy;

	private float patrolTimer;
	private float patrolDuration = 10;



	public void Execute(){

		//Debug.Log ("I am patrol state");
		Patrol ();
		enemy.Move ();

		if (enemy.target != null)
			enemy.ChangeState (new RangedState ());
	}

	public void Enter(Enemy enemy){
		this.enemy = enemy; 

	}

	public void Exit(){

	}

	public void OnTriggerEnter(Collider2D other){
		Debug.Log ("Collision");
		if (other.tag == "Patrol Edge") {
			Debug.Log ("Meet Edge");
			enemy.ChangeDirection ();
		}

	}

	private void Patrol(){
		  
		patrolTimer += Time.deltaTime;

		if (patrolTimer >= patrolDuration) {
			enemy.ChangeState (new IdleState ()); 
		}
	}
}
