using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_whiisyourparent : MonoBehaviour {

	GameObject parent;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		parent =  transform.parent.gameObject;
		Debug.Log ("npc(1): " +parent);
	}
}
