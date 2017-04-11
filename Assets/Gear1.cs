using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear1 : MonoBehaviour 
{
	
//	void GearType()
//	{
//		GearType = 1;
//	}

	void Start()
	{
		BasicGear bs1 = new BasicGear ();
		bs1.GearType = 1;

		bs1.teethColumn = new int[5] {1,1,0,0,1};

	}

}
