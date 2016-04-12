using UnityEngine;
using System.Collections;

public abstract  class Character : MonoBehaviour {

	public Animator MyAnimator { get; set; }
	public bool Attack{ get; set; }

	[SerializeField]
	protected Transform knifePos;

	[SerializeField]
	protected float movementSpeed;

	[SerializeField]
	protected bool facingRight;

	[SerializeField]
	private GameObject knifePrefab;



	// Use this for initialization
	public virtual void Start () {
		facingRight = true;
		MyAnimator = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeDirection(){
		facingRight = !facingRight;
		transform.localScale = new Vector3 (transform.localScale.x * -1, 1, 1);

	}

	/*
	public void ThrowKnife (int val){
		if (facingRight) {
			GameObject tmp = (GameObject)Instantiate (knifePrefab, knifePos.position, Quaternion);
			tmp.GetComponent<knife
		} 
		else {

		}
	}
	*/
}
