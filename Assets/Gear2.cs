using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear2 : MonoBehaviour 
{
	void Start()
	{
		BasicGear bs1 = new BasicGear ();
		bs1.GearType = 2;

		bs1.teethColumn = new int[8] {1,1,0,0,1,0,1,1};

	}

}
