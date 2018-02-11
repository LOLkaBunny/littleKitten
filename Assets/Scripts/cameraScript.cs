using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {
    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    public new Camera camera;


   // Use this for initialization
    void Start () {
        transform.position = new Vector3(0, 0, transform.position.z);

    }
	
	// Update is called once per frame
	void Update () {
        if (target)
          {
               Vector3 point = camera.WorldToViewportPoint(new Vector3(target.position.x, target.position.y + 0.75f, target.position.z));
               Vector3 delta = new Vector3(target.position.x+8f, target.position.y + 0.75f, target.position.z) - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
               Vector3 destination = transform.position + delta;

            
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
}