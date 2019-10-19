using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {
    public int maxHealth;
    float currentHealth;

    public float invincibiltyFrames = .1f;
    public GameObject hurtEffect;
    float invinceTimer;

    bool hasDied;

    Animator anim;
	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0)
        {
            if(!hasDied)
            {
                Death();
                hasDied = true;
            }
        }

        if (invinceTimer > 0)
            invinceTimer -= Time.deltaTime;
	}

    public void TakeDamage(float damage)
    {
        if (invinceTimer <= 0)
        {
            currentHealth -= damage;
            GameObject.FindGameObjectWithTag("Camera").GetComponent<Animator>().SetTrigger("Shake");
           
            anim.SetTrigger("Hurt");
            invinceTimer = invincibiltyFrames;
            Instantiate(hurtEffect, transform.position, Quaternion.identity);
           // StartCoroutine(Hitstop());
        }

    
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    IEnumerator Hitstop()

    {

        Time.timeScale = 0f;

        float RealTimeOfTimestopStart = Time.realtimeSinceStartup;

        float lengthOfTimestop = 5f / 60f;

       // while (Time.realtimeSinceStartup < RealTimeOfTimestopStart + lengthOfTimestop)

       // {

            yield return new WaitForSeconds(lengthOfTimestop);

        //}

        Time.timeScale = 1f;

       // Time.timeScale = FindObjectOfType<GameManager>().GetTimeScale();

    }
}
