using UnityEngine;
using System.Collections;
/*
 *Controlador de Killer, destruye al personaje cuando choca con el piso o el techo
*/
public class KillerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	//al entrar en contacto con este elemento, se destruye el personaje principal
	void OnTriggerEnter2D(Collider2D otherObject){		
		Destroy (otherObject.gameObject);	
		Debug.Log ("Player destroyed!");
	}
}
