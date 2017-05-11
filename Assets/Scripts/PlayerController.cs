using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
	Controlador del personaje principal "Courier"
*/

public class PlayerController : MonoBehaviour {


	public float mJumpAceleration;//aceleración en el salto
	public ItemBoxController mItemBox;//caja de items (6 items = 6 vidas)
	public GameObject mGameOverObject;//Letrero de Game over y botón de reset
	public Text mScoreText;//texto para mostrar el score (puntuación del personaje)
	private Rigidbody2D mRigidbody2D;//objeto de física del personaje
	private int mLives;//# de vidas restantes (se refiere al número de items existentes -> 6 items = 6 vidas)
	private bool mAlive;//estado de que si el personaje está vivo o muerto
	private bool mShouldJump;//estado de que si el personaje debería o no saltar 
	private int mScorePoints;//contador de puntos (score)

	private const float MAX_BOTTOM_DISTANCE= 6.0f; //distancia máxima de caída (metros desde su posición inicial hasta el piso)


	//other variables
	private float mPreviousTime;//variable de ayuda que guarda el tiempo del sistema



	// Use this for initialization
	void Start () {
		mRigidbody2D = GetComponent<Rigidbody2D> (); //obtener el objeto de física del personaje
		mAlive = true; // si jugador está vivo
		mLives=6; //# de vidas
		mShouldJump = false; //no debería estar saltando ahora 
		mPreviousTime = 0;//tiempo cero
	}

	//update para física
	// Update is called once per frame
	void FixedUpdate () {		
		jump();	 //saltar
		falling(); //caer
		doItForSeconds(0.35f); //realizar efecto de salto (si se apretó la tecla de salto) cada 350 milisegundos
	}


	//método efecto de caída (rotación del personaje cuando está cayendo)
	void falling(){
		//si la posición del personaje del sistema de coordenadas es menor que la mitad de la pantalla
		if (transform.position.y < 0.0f) {
			float currentPosition = Mathf.Abs (transform.position.y); //obtejer el valor absoluto de la posición actual en "y" del personaje
			float percentage = (currentPosition) / MAX_BOTTOM_DISTANCE; //obtener el porcentaje de actual (con respecto a la posición actual)
														// el 100% es la distancía máxima de caída que será en ese momento el giro completo del personaje
			//rotar al personaje un máximo de 60° 
			transform.localEulerAngles = new Vector3 (0, 0, -60.0f * percentage );
		}
	}

	//método de saltar
	void jump(){
		//si tocan la barra espaciadora o si tocan la pantalla touch Y el personaje está vivo, saltar
		if ((Input.GetKeyDown("space") || Input.touchCount>0 ) && mAlive) {
			mShouldJump = true; //debería estar saltando SÍ
			mPreviousTime = Time.time; //obtener el tiempo del juego
			Debug.Log ("jump!"); 
		}
	}


	//método para verificar si el personaje ha perdido
	private void checkIfPlayerLose(){
		mAlive=(mLives>0);
		if(!mAlive) mGameOverObject.SetActive(true);
	}		



	//realizar la acción por n segundos (en este caso 0.35 segundos)
	void doItForSeconds(float seconds){

		//si debería estar saltando, a saltar!
		if (mShouldJump) {			
			mRigidbody2D.AddForce (Vector2.up* mRigidbody2D.mass * mJumpAceleration);//poner una fuerza contraría al peso para ir hacía arriba
		}

		//si ya pasó los 0.35 segundos
		if(Time.time - mPreviousTime >seconds)
		{
			mShouldJump = false;//ya no debería estar saltando
		}


	}


	//método para mostrar el texto
	void updateScoreText(){
		mScoreText.text = "<b>Score:</b> "+mScorePoints;
	}

	//cuando colisione (trigger) con algún objeto
	void OnTriggerEnter2D(Collider2D other){
		switch (other.gameObject.tag) {
			case "tower"://si es una torre <-
				mItemBox.dropItem ();//soltar un item (perder una vida)
				mLives--; //perder una vida
				Debug.Log ("Dropping item");
				break;
			case "floor_killer"://si chocas con el techo o el piso <-
				mLives = 0;//eliminar al personaje asignandole cero vidas
				break;
			case "coin"://si chocas con un coin 
				mScorePoints++;//sumarlo a tu score
				updateScoreText ();//actualizar el texto del score en pantalla
				break;
		}			

		checkIfPlayerLose (); //chequear si el usuario perdio o no

	}
}
