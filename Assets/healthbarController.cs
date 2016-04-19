using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class healthbarController : MonoBehaviour {
	public Image healthBar;
	private float health;
	private int countdown=0;
	// Use this for initialization
	void Start () {
		health = GameManager.Instance.Health;
		healthBar.rectTransform.localScale = new Vector3 ( health/100, healthBar.rectTransform.localScale.y, healthBar.rectTransform.localScale.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (health != GameManager.Instance.Health) {
			healthBar.color = Color.yellow;
			countdown = 20;
		} else {
			if (countdown == 0) {
				healthBar.color = Color.red;
			} else {
				healthBar.color = Color.yellow;
				countdown--;
			}
		}
		health = GameManager.Instance.Health;
		healthBar.rectTransform.localScale = new Vector3 ( health/100, healthBar.rectTransform.localScale.y, healthBar.rectTransform.localScale.z);

	}
}
