using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class healthbarController : MonoBehaviour {
	public Image healthBar;
	private float health;
	// Use this for initialization
	void Start () {
		health = GameManager.Instance.Health;
		healthBar.rectTransform.localScale = new Vector3 ( health/100, healthBar.rectTransform.localScale.y, healthBar.rectTransform.localScale.z);
	}
	
	// Update is called once per frame
	void Update () {
		health = GameManager.Instance.Health;
		healthBar.rectTransform.localScale = new Vector3 ( health/100, healthBar.rectTransform.localScale.y, healthBar.rectTransform.localScale.z);

	}
}
