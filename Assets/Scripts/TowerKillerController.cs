using UnityEngine;
using System.Collections;
/*
 * Controlador de TowerKiller, se encarga de destruir las torres que choquen con esta
*/
public class TowerKillerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//al entrar en contacto con este elemento, se destruye la torre o moneda
	void OnTriggerEnter2D(Collider2D otherObject){		
		Destroy (otherObject.gameObject);
	}
}
