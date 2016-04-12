using UnityEngine;
using System.Collections;

public class EnemyOld : MonoBehaviour {

	[SerializeField]
	private float rotationSpeed = 180; // In degrees per second

	[SerializeField]
	private float movementSpeed = 1f; // In units per second

	[SerializeField]
	private float meshRadius = 1f; // In units

	private IEnumerator turnTowardsPlayerCoroutine;
	private IEnumerator moveTowardsPlayerCoroutine;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			float playerDistance = Vector3.Distance(collider.transform.position, transform.position);

			// Ignore trigger events from the inner colliders
			if (playerDistance >= 2f * meshRadius)
			{
				turnTowardsPlayerCoroutine = TurnTowardsPlayer(collider.transform);
				moveTowardsPlayerCoroutine = MoveTowardsPlayer(collider.transform);
				StartCoroutine(turnTowardsPlayerCoroutine);
				StartCoroutine(moveTowardsPlayerCoroutine);
			}
		}
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.tag == "Player")
		{
			float playerDistance = Vector3.Distance(collider.transform.position, transform.position);

			// Ignore trigger events from the inner colliders
			if (playerDistance >= 2f * meshRadius)
			{
				StopCoroutine(turnTowardsPlayerCoroutine);
				StopCoroutine(moveTowardsPlayerCoroutine);
			}
		}
	}

	private IEnumerator TurnTowardsPlayer(Transform player)
	{
		while (true)
		{
			Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position, Vector3.up);
			targetRotation.x = 0f;
			targetRotation.z = 0f;

			transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
			yield return 0;
		}
	}

	private IEnumerator MoveTowardsPlayer(Transform player)
	{
		while (true)
		{
			Vector3 playerDirection = transform.position - player.position;
			playerDirection.y = 0;
			playerDirection = playerDirection.normalized;

			Vector3 deltaMovement = playerDirection * movementSpeed * Time.deltaTime;

			int layermask = LayerMask.GetMask("Default");
			Vector3 movingTowards = transform.position - playerDirection*meshRadius + (new Vector3(0f, 0.1f, 0f));
			if (Physics.Raycast(movingTowards, Vector3.down, 0.25f, layermask))
			{
				transform.position -= deltaMovement;
			}

			yield return 0;
		}
	}
}
