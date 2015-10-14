using UnityEngine;
using System.Collections;

public class PlayerCamera_v0 : MonoBehaviour {

	private CharacterActions actions;

	[SerializeField]
	private Transform target;
	private Transform anchor;

	[SerializeField]
	private float distance = 3.5f;

	[SerializeField]
	private float vertAngle = 2.5f;

	[SerializeField]
	private float horizAngle = 0f;

	[SerializeField]
	private float targetDampTime = 0.1f;

	[SerializeField]
	private float followSpeed = 30f;

	[SerializeField]
	private Vector3 rotationOffset = new Vector3( 0, 2.2f, 0 );

	private Vector3 velocityTargetSmooth = Vector3.zero;

	private Vector3 targetPosition;
	private Vector3 targetDirection;

	// Use this for initialization
	void Start () {
		anchor = GameObject.FindGameObjectWithTag( "CameraAnchor" ).transform;
	}

	public void Init( CharacterActions actions )
	{
		this.actions = actions;
	}

	// Update is called once per frame
	void LateUpdate () 
	{
		moveAnchor();
		calculateAnchorRotation();
		calculateCameraPosition();

	}

	private void moveAnchor()
	{
		anchor.position = Vector3.SmoothDamp( anchor.position, target.position, ref velocityTargetSmooth, targetDampTime );
	}

	private void calculateAnchorRotation()
	{
		if( actions.LookLeft.Value > 0 )
			horizAngle -= 1;
		else if( actions.LookRight.Value > 0 )
			horizAngle += 1;

		if( horizAngle >= 360 ) horizAngle = 0;
		else if( horizAngle < 0 ) horizAngle = 360;

		if( actions.LookUp.Value > 0 )
			vertAngle -= ( 1 * 0.13f );
		else if( actions.LookDown.Value > 0 )
			vertAngle += ( 1 * 0.13f );

		if( vertAngle > 5 ) vertAngle = 5;
		else if( vertAngle < 0 ) vertAngle = 0;

		Quaternion newRotation = Quaternion.AngleAxis( horizAngle, Vector3.up );
		anchor.rotation = Quaternion.Slerp( anchor.rotation, newRotation, Time.deltaTime * followSpeed );
		Debug.DrawRay( new Vector3( anchor.position.x, anchor.position.y + 0.1f, anchor.position.z ) , anchor.forward, Color.green);
	}

	private void calculateCameraPosition ()
	{
		targetPosition = anchor.position + ( anchor.up * vertAngle ) + ( -anchor.forward * distance );
		compensateForCollisions( ref targetPosition );
		transform.position = Vector3.Lerp( transform.position, targetPosition, Time.deltaTime * followSpeed );
	}

	private void calculateCameraRotation ()
	{
		targetDirection = anchor.position + rotationOffset;
		transform.rotation = Rotation.LookAtVector( transform, targetDirection, 500 );
		//transform.LookAt( targetDirection );
	}

	private void compensateForCollisions( ref Vector3 to_pos )
	{
		RaycastHit hit = new RaycastHit();
		if( Physics.Linecast( transform.position, to_pos, out hit ) )
		{
			to_pos = new Vector3( hit.point.x, to_pos.y, hit.point.z );
		}
	}
}
