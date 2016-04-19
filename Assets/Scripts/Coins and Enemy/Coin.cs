using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {
	[SerializeField]
	private float rotateSpeed = 1.0f;

	[SerializeField]
	private float floatSpeed = 0.5f; // In cycles (up and down) per second

	[SerializeField]
	private float movementDistance = 0.5f; // The maximum distance the coin can move up and down.


	private float startingY;
	private bool isMovingUp = true;

	void OnTriggerEnter2D(Collider2D collider2d)
	{
		if (collider2d.gameObject.tag == "PlayerSnow" || collider2d.gameObject.tag == "PlayerCloud")
		{
			Pickup();
		}
	}

	private void Pickup()
	{
		GameManager.Instance.NumCoins++;
		Destroy (gameObject);
	}

	// Use this for initialization
	void Start () {
		startingY = transform.position.y;
		transform.Rotate (transform.up, Random.Range (0f, 360f));

		StartCoroutine (Spin ());
		StartCoroutine (Float ());
	}



	private IEnumerator Float()
	{
		while (true)
		{
			float newY = transform.position.y + (isMovingUp ? 1 : -1) * 2 * movementDistance * floatSpeed * Time.deltaTime;

			if (newY > startingY + movementDistance)
			{
				newY = startingY + movementDistance;
				isMovingUp = false;
			}
			else if (newY < startingY)
			{
				newY = startingY;
				isMovingUp = true;
			}

			transform.position = new Vector3(transform.position.x, newY, transform.position.z);
			yield return 0;
		}
	}
	private IEnumerator Spin()
	{
		while (true) 
		{
			transform.Rotate (transform.up, 360 * rotateSpeed * Time.deltaTime);
			yield return 0;
		}
	}
}
