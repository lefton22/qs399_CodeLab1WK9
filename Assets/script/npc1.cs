using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc1 : MonoBehaviour {
	
	GameObject parent;
	Vector3 v3_parent;
	Vector3 v3_intersectPoint;
	Vector3 v3_intersectPoint2;

	Vector3 v3_worldPos;
	GameObject nearestWheel;

	GameObject lw1;
	GameObject lgo_collide;
	List<GameObject> lgo_collides;
	List<GameObject> lgo_collides_mother;

	float radius_collided;
	float radius_collided2;

	bool isChangeTrail;
	bool isChangeTrail2;

	float meetTime;
	float meetTime2;



	void Start () 
	{
////find the parent and get the parent's axis


		lw1 = GameObject.Find ("w1");

		//Debug.Log (" npc1's parent: " + transform.parent.gameObject);
		isChangeTrail = true;
		isChangeTrail2 = true;


	}
	

	void Update ()
	{
		parent =  transform.parent.gameObject;

		float radius = parent.transform.localScale.x;

		v3_parent = parent.transform.position;

	
		//transform.localPosition = new Vector3 (/*parent.transform.localScale.x/4f*/0.5f,0,0);

		////get all the gameobjects collided with this npc's parent?

		if (parent != lw1)
		{
			lgo_collides = parent.GetComponent<follow_rotate> ().go_collides; 

			//Debug.Log ("go_cillides: " + lgo_collides[0] + " " + lgo_collides[1] + " " + lgo_collides[2] );

			if( Time.time - meetTime > 1f)
			{	
				for (int i = 0; i < lgo_collides.Count; i++) { 

////find the collided wheel from the parent wheel, and get the position
					Vector3 v3_lgo_collides = lgo_collides [i].transform.position;

					//float radius_parent = parent.GetComponent<follow_rotate> ().radius_currentWheel;

					if (lgo_collides [i] == lw1) {
						radius_collided = lgo_collides [i].GetComponent<rotate> ().radius_currentWheel; 
					}

					if (lgo_collides [i] != lw1) {
						radius_collided = lgo_collides [i].GetComponent<follow_rotate> ().radius_currentWheel; 
					}
					//Debug.Log ("v3_parentsNearest: " +v3_parentsNearest + "this parent: " + v3_parent);

////calculate the cross point of two wheels
					//Vector3 dist_two = v3_parentsNearest - v3_parent;
					//Debug.Log ("dist_two: " + dist_two);
					Vector3 dist_two = v3_lgo_collides - v3_parent;

					//v3_intersectPoint = v3_parent + dist_two.normalized * radius_parent / 2;
					//Debug.Log (parent + " and " + lgo_collides[i] + "'s cross point: " + v3_intersectPoint);

					v3_intersectPoint = v3_parent + dist_two.normalized * /*radius_collided / 2f*/ radius / 2f;

//// create a collider at the position of cross point, and if any npc collide with this collider, change tha parent
					v3_worldPos = transform.TransformPoint (transform.position);
					//Debug.Log ("v3_worldPos: " + v3_worldPos);

					//nearestWheel = parent.GetComponent<follow_rotate> ().closestObject; // no need any more

////ctreat only one cross point for every tw crossing wheels
					/// if the cross point is near the npc,cross

					//Debug.Log(lgo_collides [i] + " cross point: " + v3_intersectPoint);
					//Debug.Log(lgo_collides [i] +" 差值x：" + Mathf.Abs (v3_intersectPoint.x - transform.position.x)+ " 差值y: " +Mathf.Abs (v3_intersectPoint.y - transform.position.y));
					if ( 
						Mathf.Abs (v3_intersectPoint.x - transform.position.x) < 0.2f &&
						Mathf.Abs (v3_intersectPoint.y - transform.position.y) < 0.2f && isChangeTrail) {
						Transform currentWorldPos = transform;

						//Debug.Log (currentWorldPos.position +": local position: " + localPos);
						//Destroy(parent);

						transform.SetParent (lgo_collides [i].transform); 
						parent = lgo_collides [i];

						//Vector3 localPos = currentWorldPos . InverseTransformPoint(currentWorldPos.position);
						//transform.position =  currentWorldPos.position + new Vector3(0.2f, 0.2f,0);

						transform.position = v3_intersectPoint;

						//transform.localPosition.x = lgo_collides [i].transform.localScale.x / 2;
						//transform.localPosition = new Vector3 (lgo_collides[i].transform.lossyScale.x/2, transform.localPosition.y, transform.localPosition.z);
						//transform.position = new Vector3 (2f, 0, 0);
						//Debug.Log("change the trial! to: " + lgo_collides [i] +i);
						////need to add a limitation now to avoid the npc1 hop forever
						isChangeTrail = false;

						meetTime = Time.time;

					}

//					if (	/* Mathf.Abs (v3_intersectPoint.x - transform.position.x) > 0.2f &&
//				Mathf.Abs (v3_intersectPoint.y - transform.position.y) > 0.2f */
//						Time.time - meetTime > 1.5f) {
//						isChangeTrail = true;
//					}
				}

				//Debug.Log("isChangeTrial: " +isChangeTrail);

			}
		}


//// if parent is w1

		if (parent == lw1)
		{
			//Debug.Log (gameObject + ": parent is w1.");
			lgo_collides_mother = parent.GetComponent<rotate> ().go_collides_mother; 


			if( Time.time - meetTime > 1f)
			{	
			for (int i = 0; i < lgo_collides_mother.Count; i++) 
			{ 
				
				float a = v3_intersectPoint2.x - transform.position.x;
				float b = v3_intersectPoint2.y - transform.position.y;

				Vector3 v3_lgo_collides2 = lgo_collides_mother [i].transform.position;


				radius_collided2 = lgo_collides_mother[i].GetComponent<follow_rotate> ().radius_currentWheel; 

				Vector3 dist_two2 = v3_lgo_collides2 - v3_parent;

				v3_intersectPoint2 = v3_parent + dist_two2.normalized * /*radius_collided / 2f*/ radius / 2f;

				//// create a collider at the position of cross point, and if any npc collide with this collider, change tha parent
				v3_worldPos = transform.TransformPoint (transform.position);
				//Debug.Log ("v3_worldPos: " + v3_worldPos);



				//Debug.Log ("diff_x: " +  a + " diff_y: " + b );

				if ( 
					Mathf.Abs (v3_intersectPoint2.x - transform.position.x) < 0.2f &&
					Mathf.Abs (v3_intersectPoint2.y - transform.position.y) < 0.2f && isChangeTrail2) 
				{
					Debug.Log (parent + ": in mother gear and move!");

					Transform currentWorldPos = transform;

					//Debug.Log (currentWorldPos.position +": local position: " + localPos);
					//Destroy(parent);

					transform.SetParent (lgo_collides_mother [i].transform); 
					parent = lgo_collides_mother [i];

					transform.position = v3_intersectPoint2;

					isChangeTrail2 = false;

					meetTime2 = Time.time;

				}

				if (Time.time - meetTime2 > 1.5f) 
				{
					isChangeTrail2 = true;
				}

				//Debug.Log("isChangeTrial: " +isChangeTrail2);
				}
			}
		}
		//Debug.Log ("npc's nearest gameobject is: " + nearestWheel);

//		//if there is no same collision here
//		//if there is no collider there, then create the collider:
//		//once: 
//		GameObject wheel_n = Instantiate(Resources.Load("crosspoint"), v3_intersectPoint, Quaternion.identity) as GameObject; // "w2"is the name in the Resources file,
//		                                                                                             //mouseV3 is the place which it will be born. 	

	}


	///  and if any npc collide with this collider, change tha parent
//	void OnCollisionEnter(Collision collision)
//	{
//		//Debug.Log ("");
//		//transform.SetParent(nearestWheel.transform);
//	}


	void OnTriggerEnter2D (Collider2D other)
	{
//		Debug.Log ("collide with mother gear");


	}
}
