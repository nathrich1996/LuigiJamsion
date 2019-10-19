using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
    public float damage;
    public LayerMask enemyLayer;

    BoxCollider2D box;
	// Use this for initialization
	void Start () {
        box = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Collider2D[] hit = Physics2D.OverlapBoxAll(box.bounds.center, box.bounds.extents, 0, enemyLayer);

        if (hit!= null)
        {
            for (int i = 0; i < hit.Length; i++)
            {
                hit[i].GetComponentInParent<HealthManager>().TakeDamage(damage);
            }
        }
	}
}
