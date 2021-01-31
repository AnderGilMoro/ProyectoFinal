using System.Collections;
using System.Collections.Generic;
using UnityEngine.Windows.Speech;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
	public float speed = 10.0f;
	private GameObject[] walls;
	KeywordRecognizer kr;
	private string[] keywords = new string[]{"Avanza", "Para", "Retrocede"};
	private GameObject textoMunicion;

	private int avanzar;

	public int municion = 2;

    // Start is called before the first frame update
    void Start()
    {
 		kr = new KeywordRecognizer(keywords);
        kr.OnPhraseRecognized += recognized;
        kr.Start();

        avanzar = 0;

        textoMunicion = GameObject.FindWithTag("municion");
        textoMunicion.GetComponent<Text>().text = "Munición: " + municion.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    	if (Input.GetButton("Fire1") || avanzar == 1) {
    		transform.position += Camera.main.transform.forward * speed * Time.deltaTime;
        }
        // else if (Input.GetButton("Fire2") || avanzar == 2) {
        // 	transform.position -= Camera.main.transform.forward * speed * Time.deltaTime;
        // }

        if (Input.GetMouseButtonDown(2)) {
	    	if (municion > 0) {
		    	municion -= 1;
		    	textoMunicion.GetComponent<Text>().text = "Municion: " + municion.ToString();
		    }
		}
    }

    private void recognized(PhraseRecognizedEventArgs data) 
    {
    	if (data.text == "Avanza") {
    		avanzar = 1;
    		Debug.Log("Avanzando");
    	}
    	else if (data.text == "Para") {
    		avanzar = 0;
    		Debug.Log("Parado");
    	}
    	else if (data.text == "Retrocede") {
    		avanzar = 2;
    		Debug.Log("Retrocediendo");
    	}
    }
}
