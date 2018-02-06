using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starScript : MonoBehaviour {
    public float x;
    public float y;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void GetX(float a)
    {
        x = a;
    }

    void GetY(float a)
    {
        y = a;
    }

    float SetX()
    {
        return x;
    }

    float SetY()
    {
        return y;
    }
}
