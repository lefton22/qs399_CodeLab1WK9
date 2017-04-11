using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

	public float speed = 30f;  // ?how can i set this value on the Inspector?
	//public float OriRoSpeed;

//this rotating speed is the first energy of this world
	public float Speed
	{
		get{ return speed; }
		set { speed = value;}
	} 

    public float timeHere;

	public float radius_currentWheel;

	GameObject go_collide2;
	public List<GameObject> go_collides_mother;

	void Start () 
	{

		//Speed = OriRoSpeed;
	}

	void Update () 
	{
		radius_currentWheel = transform.localScale.x;

		transform.Rotate (0,0, Time.deltaTime * Speed);

////create a time of this wheel
		timeHere = timeHere + Time.deltaTime * Speed;
		//Debug.Log ("TimeHere w1: " + timeHere);

		for (int i = 0; i < go_collides_mother.Count; i++) 
		{
			//Debug.Log ("colliding what's in go_collides_mothers: " + i +": "+ go_collides_mother [i]);
		}
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		//sDebug.Log ("collide");
		if (other.tag == "wheel") 
		{
			go_collide2 = other.gameObject;

			if (go_collides_mother.Contains (go_collide2)) 
			{
			}
			else
			{	
				go_collides_mother.Add (go_collide2);
			}
		}

	}
}
