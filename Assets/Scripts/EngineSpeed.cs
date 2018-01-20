using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSpeed : MonoBehaviour {

    void SetSpeed()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        if (speed_factor < 0f)
            speed_factor = 0f;
        else if (speed_factor > 1f)
            speed_factor = 1f;

        ps.startSpeed = speed_factor;
    }

    public float speed_factor; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SetSpeed();

    }
}
