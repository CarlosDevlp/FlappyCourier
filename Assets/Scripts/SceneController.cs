using UnityEngine;
using System.Collections;


/*
 * Controlador de la escena
*/
public class SceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//método para resetear el juego
	public void restart(){
		UnityEngine.SceneManagement.SceneManager.LoadScene (0);		
	}
}
