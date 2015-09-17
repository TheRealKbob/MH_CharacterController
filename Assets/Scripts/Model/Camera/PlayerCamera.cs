using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

	[SerializeField]
	private float distance = 5; //In Meters

	[SerializeField]
	private float angle = 2;

	[SerializeField]
	private float smooth = 3;

	[SerializeField]
	private Vector3 offset = new Vector3(0, 0, 0);

	[SerializeField]
	private float targetDampTime = 0.1f;

	private Vector3 velocityTargetSmooth = Vector3.zero;
	private Vector3 lookDirection;
	private Transform target;
	private Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag( "CameraAnchor" ).transform;
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		Vector3 targetOffset = target.position + offset;

		lookDirection = targetOffset - this.transform.position;
		lookDirection.y = 0f;
		lookDirection.Normalize();

		targetPosition = targetOffset + Vector3.up * angle - lookDirection * distance;
		smoothPosition( this.transform.position, targetPosition );

		transform.LookAt( target );
	}

	private void smoothPosition( Vector3 fromPosition, Vector3 toPosition )
	{
		transform.position = Vector3.SmoothDamp( fromPosition, toPosition, ref velocityTargetSmooth, targetDampTime );
	}

}
