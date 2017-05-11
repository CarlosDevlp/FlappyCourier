using UnityEngine;
using System.Collections.Generic;

/*
 *Controlador del itemBox, contiene todos los items
*/
public class ItemBoxController : MonoBehaviour {

	// Use this for initialization
	private List<GameObject> mItemList ;//lista de items

	void Start () {
		mItemList = new List<GameObject> ();

		//Obtener cada item y listarlo
		for(int i=0;i<transform.childCount;i++)
			mItemList.Add(transform.GetChild(i).gameObject);
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//método para soltar cada item y perder una vida
	public void dropItem(){
		int itemPos = mItemList.Count-1;//posición del item a soltar
		//si aún hay items
		if (itemPos >= 0) {			
			Rigidbody2D rigidBody= mItemList [itemPos].GetComponent<Rigidbody2D>();//obtenemos su objeto de física
			rigidBody.gravityScale = 1.0f;//le asignamos gravedad para que caíga
			mItemList.RemoveAt(itemPos);//eliminamos de la lista de vidas
		}
	}
}
