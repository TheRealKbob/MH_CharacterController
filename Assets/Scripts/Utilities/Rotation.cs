﻿using UnityEngine;
using System.Collections;

public class Rotation {

	public static Quaternion LookAtVector( Transform fromTransform, Vector3 toDirection, float speed )
	{
		Vector3 direction = ( toDirection - fromTransform.position ).normalized;
		Quaternion lookRotation = Quaternion.LookRotation( direction );
		return Quaternion.Slerp( fromTransform.rotation, lookRotation, Time.deltaTime * speed );
	}

}