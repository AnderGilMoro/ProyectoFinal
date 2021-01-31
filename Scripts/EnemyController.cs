using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyController : MonoBehaviour
{
	public float speed = 8.0f;
	Rigidbody rb;
	private Vector3 playerSpawnPos;
	private Vector3 spawnPos;
	private Quaternion spawnRot, playerSpawnRot;
	GameObject player;

	public SceneController sceneController;
	public bool onShoot = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("player");

        playerSpawnPos = player.transform.position;
        playerSpawnRot = player.transform.rotation;
        spawnPos = transform.position;
        spawnRot = transform.rotation;
        
        sceneController.shootEvent += shoot;

        Input.location.Start();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
    	if (collision.gameObject.tag == "wall") {
    		Vector3 rot = transform.rotation.eulerAngles;
			rot = new Vector3(rot.x, rot.y+180, rot.z);
			transform.rotation = Quaternion.Euler(rot);
    	}
    	else if (collision.gameObject.tag == "player") {
			Input.location.Start();
	    	if (Input.location.status == LocationServiceStatus.Running) {
	        	Debug.Log("Latitud: " + Input.location.lastData.latitude);
	        	Debug.Log("Longitud: " + Input.location.lastData.longitude);
	        	Debug.Log("Altitud: " + Input.location.lastData.altitude);
        	} else {
        		Debug.Log("No se puede acceder al GPS");
        	}
        	
    		SceneManager.LoadScene("SampleScene"); //Load scene called Game
    	}
    }

    private void shoot()
    {
    	Debug.Log("Shoot" + onShoot);
    	if(player.GetComponent<CharacterController>().municion > 0 && onShoot) {
    		Destroy(gameObject);
    		sceneController.shootEvent -= shoot;
    	}
    }
}
