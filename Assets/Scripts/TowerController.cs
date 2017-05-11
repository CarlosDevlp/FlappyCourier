using UnityEngine;
using System.Collections;
/*
 * Controlador para Tower, permite que este corra hacía la izquierda
 * obstáculo para el personaje principal
*/
public class TowerController : MonoBehaviour {

	public float mMoveSpeed;//velocidad de movimiento
	private Rigidbody2D mRigidbody2D;
	// Use this for initialization
	void Start () {
		mRigidbody2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		goLeft ();
	}

	//método para ir a la izquierda
	void goLeft(){
		//moverse hacía la izquerda
		transform.Translate(Vector2.left*mMoveSpeed);
	}
		
}
