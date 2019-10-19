using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour {

    public BoxCollider2D zone;
    float timer;
	// Use this for initialization
	void Start () {
        timer = 20.0f;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
	}
}
