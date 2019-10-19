using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempEffect : MonoBehaviour {
    public float frames;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Invoke("KillObject", frames);
	}

    void KillObject()
    {
        Destroy(gameObject);
    }
}
