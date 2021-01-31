using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
	public delegate void shoot();
    public event shoot shootEvent = delegate { };

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(2)) {
            if (shootEvent != null) {
                shootEvent();
            }
        }
    }
}
