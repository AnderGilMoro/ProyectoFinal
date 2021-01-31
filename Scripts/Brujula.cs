using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brujula : MonoBehaviour
{
	public Transform player;
	Vector3 vector;

    void Start()
    {
    	Input.location.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Input.compass.enabled = true;
    	Quaternion q = Quaternion.Euler(0, Input.compass.trueHeading, 0);
    	Debug.Log(q);
    	vector = q.ToEulerAngles();
    	//transform.rotation = Quaternion.Euler(0, Input.compass.trueHeading, 0);


    	//vector.z = player.eulerAngles.y;
    	transform.localEulerAngles = vector;
    }
}
