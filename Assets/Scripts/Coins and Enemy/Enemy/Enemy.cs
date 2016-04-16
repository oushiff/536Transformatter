using UnityEngine;
using System.Collections;

public class Enemy : Character {


	private IEnemyState currentState;
	 
	public GameObject target{get; set;} 

	// Use this for initialization
	public override void Start () {
		base.Start ();

		ChangeState (new IdleState ());
	}
	
	// Update is called once per frame
	void Update () {
		currentState.Execute ();

		LookAtTarget ();
	
	}

	private void LookAtTarget(){
		if (target != null) {
			float xDir = target.transform.position.x - transform.position.x;

			if (xDir < 0 && facingRight || xDir > 0 && !facingRight) {
				ChangeDirection ();
			}
		}
	}


	public void ChangeState(IEnemyState newState){
		if (currentState != null) { //If there already exist a state, exit it. 
			currentState.Exit ();
		}
		currentState = newState;
		currentState.Enter (this);
	}

	public void Move(){
		MyAnimator.SetFloat ("speed", 1);

		transform.Translate (GetDirection () * movementSpeed * Time.deltaTime);
	}

	public Vector2 GetDirection(){

		return facingRight ? Vector2.right : Vector2.left;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			Debug.Log ("Player's health is deducted");
			GameManager.Instance.Health -= 50;
			Debug.Log ("Current Health:" + GameManager.Instance.Health);
			if (GameManager.Instance.Health <= 0) {
				GameManager.Instance.RestartGame ();
			}
		}
			
		else currentState.OnTriggerEnter(other);
	}

	[SerializeField]
	private GameObject enemySelf;

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			Debug.Log ("Enemy died");
			Destroy (enemySelf); // the health is deducted, and enemy died
		}
	}

}
