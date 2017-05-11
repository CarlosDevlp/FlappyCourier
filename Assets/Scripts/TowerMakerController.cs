using UnityEngine;
using System.Collections;
using AssemblyCSharp;

/*
 * Controlador de TowerMaker, se encarga de crear torres que sirven como 
 * obstáculo para el personaje principal
*/
public class TowerMakerController : MonoBehaviour {

	public Transform mTowerPrefab;//prefab de la torre a crear
	public Transform mCoin;//prefab de la moneda o objeto que da puntos
	private float mPreviousTime;//tiempo del juego o sistema
	private float mSecondsForCreation;//segundos de espera entre creación de torres
	// Use this for initialization
	void Start () {
		mPreviousTime = 0.0f;
		mSecondsForCreation = 2.0f;

	}
	
	// Update is called once per frame
	void Update () {
		WaitForSeconds(mSecondsForCreation);//cada 2 segundos crear dos torres con una moneda con puntos
	}
		


	void WaitForSeconds(float seconds){

		if (Time.time - mPreviousTime >= seconds) {
			Debug.Log ("Creating a new tower");


			//top tower (torre de arriba)
			Instantiate(mTowerPrefab,new Vector3(transform.position.x,Random.Range (5,10), -10.0f),transform.rotation); 

			//coin (puntos en el medio)
			Instantiate(mCoin,new Vector3(transform.position.x+3.0f,0,-10.0f ),new Quaternion(0,0,0,0));

			//bottom tower (torre de abajo)
			Instantiate(mTowerPrefab,new Vector3(transform.position.x,Random.Range (-7,-5),-10.0f ),new Quaternion(0,0,0,0));


			mPreviousTime = Time.time; //obtener tiempo actual del juego
		}


	}
}
