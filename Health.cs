using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Scene = UnityEngine.SceneManagement.Scene;

public class Health : MonoBehaviour
{
    //public TextMeshProUGUI healthText;

    public Slider slider;
    public float health = 10;
    public int maxHealth = 10;
    public int healing = 4;
    public string sceneName;
    public AudioClip potionDrink;

    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        //healthText.text = "Health: " + health;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        string otherTag = collision.gameObject.tag;
        
        if (otherTag == "ObjectDamage")
        {
            health -= 2;
            if (health <= 0)
            {
				Scene scene = SceneManager.GetActiveScene();
				SceneManager.LoadScene(scene.name);
			}
        }

        else if (otherTag == "Enemy")
        {
            health -= 0.1f;
            slider.value = health;
    
            if (health <= 0)
            {
                Time.timeScale = 0;
				SceneManager.LoadScene(sceneName);
			}
        }

        else if (otherTag == "HealingPowerUp")
        {
            health += healing;
            slider.value = health;
            Destroy(collision.gameObject);
            GetComponent<AudioSource>().PlayOneShot(potionDrink);
            if (health > maxHealth)
            {
                health = maxHealth;

            }
        }

        //else if (otherTag == "EBulletDamage")
        //{
        //health -= 4;
        //if (health <= 0)
        //{
        //Scene scene = SceneManager.GetActiveScene();
        //SceneManager.LoadScene(scene.name);
        //}
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
		string otherTag = collision.gameObject.tag;


		if (otherTag == "DeathPlane")
		{
			health -= 15f;
			slider.value = health;

			if (health <= 0)
			{
				Time.timeScale = 0;
				SceneManager.LoadScene(sceneName);
			}
		}
	}
}
