using UnityEngine;
using System.Collections;

public enum CameraState
{
	FREE,
	TARGETING
}

public class PlayerCamera : MonoBehaviour {

	private Transform anchor;
	private Transform target;

	public CameraState State{ get; private set; }

	void Start()
	{
		State = CameraState.FREE;
		anchor = GameObject.FindGameObjectWithTag( "CameraAnchor" ).transform;
	}

	//Update
	public void ApplyMoveVector( Vector2 move )
	{
		
	}
	
}
