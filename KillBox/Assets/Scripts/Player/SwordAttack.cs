using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour {
    Animator anim;
    PlayerControllerTemplate controller;
    public Transform swordPos;

    bool attacking;
    public float attackFrames;
    float attackTimer;
	// Use this for initialization
	void Start () {
        controller = GetComponent<PlayerControllerTemplate>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if(!attacking)
        UpdateSwordPos(controller.GetDirection());

        if (Input.GetButtonDown("Attack") && !attacking)
        {
            anim.SetTrigger("Attack");
            attacking = true;
            attackTimer = attackFrames;
        }

        if (attackTimer <= 0)
        {
            attacking = false;
        }
        else
        {
            attackTimer -= Time.deltaTime;
        }
	}

    void UpdateSwordPos(Vector2 vector)
    {
        if (vector != Vector2.zero)
        {
            if (vector.y > 0)
                swordPos.localRotation = Quaternion.Euler(0, 0, 0);
            else if (vector.y < 0)
                swordPos.localRotation = Quaternion.Euler(0, 0, 180);
            else if (vector.y == 0 && vector.x > 0)
                swordPos.localRotation = Quaternion.Euler(0, 0, 270);
            else if (vector.y == 0 && vector.x < 0)
                swordPos.localRotation = Quaternion.Euler(0, 0, 90);
        }
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackFrames);
       // attacking = false;
    }
}
