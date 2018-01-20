using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPDisplayScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public int max;

    public void ChangePoints(int p)
    {
        if (p < max)
        {
            Text txt = GetComponent<Text>();
            string tmp = "";
            for( int i =0; i<p; ++i )
            {
                tmp += '|';
            }
            txt.text = tmp;
        }
    } 


}
