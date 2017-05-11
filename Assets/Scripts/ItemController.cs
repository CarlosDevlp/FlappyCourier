using UnityEngine;
using System.Collections;
/*
 *Controlador del item, un item es una vida
*/
public class ItemController : MonoBehaviour {

	// Use this for initialization
	private Animator mAnimator;//objeto de animación
	void Start () {
		mAnimator=GetComponent<Animator> ();//obtengo la animación
		mAnimator.Play("item_list",0, Random.value); //busco aleatoriamente un item (frame del item para que me salga una imagen distinta)
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
