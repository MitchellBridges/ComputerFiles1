using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
	public float health = 10;
	public GameObject Enemy;
	public Slider slider;
	// Start is called before the first frame update
	void Start()
	{
		slider.maxValue = health;
		slider.value = health;
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		string otherTag = collision.gameObject.tag;
		if (otherTag == "PlayerBullet")
		{
			health -= 3;
			Destroy(collision.gameObject);
			slider.value = health;
			if (health <= 0)
			{
				Debug.Log("Enemy Killed");
				GameObject.Destroy(Enemy);
			}
		}
	}
}
