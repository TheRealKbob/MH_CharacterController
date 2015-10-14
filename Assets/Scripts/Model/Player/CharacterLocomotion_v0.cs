using UnityEngine;
using System.Collections;

public class CharacterLocomotion_v0 : MonoBehaviour {

	[SerializeField]
	private Animator animator;
	private AnimatorStateInfo stateInfo;

	[SerializeField]
	private GameObject pivotObject;

	[SerializeField]
	private float directionDampTime = 0.25f;

	[SerializeField]
	private float directionSpeed = 3.0f;

	[SerializeField]
	private float rotationDegreePerSecond = 120f;

	private float speed;
	private float direction;


	private InputBindings bindings;
	private CharacterActions actions;

	private int m_LocomotionID = 0;

	public bool isInLocomotion{ get{ return stateInfo.nameHash == m_LocomotionID; } }

	private Vector2 moveForce;

	// Use this for initialization
	void Start () {

		if(animator == null)
			animator = GetComponent<Animator>() as Animator;

		m_LocomotionID = Animator.StringToHash( "Base Layer.Locomotion" );

	}

	public void Init( InputBindings bindings )
	{
		this.bindings = bindings;
		actions = this.bindings.Actions;
	}
	
	// Update is called once per frame
	void Update () {
		if(bindings != null)
		{
			stateInfo = animator.GetCurrentAnimatorStateInfo(0);

			CalculateMoveValue( actions.Move.Value );
			
		}
	}

	void FixedUpdate()
	{
		ApplyMoveValue( moveForce );
	}

	public void CalculateMoveValue( Vector2 force )
	{
		moveForce = force;
		InputToWorldSpace( force, this.transform, pivotObject.transform, ref direction, ref speed );
		animator.SetFloat( "Speed", speed );
		animator.SetFloat( "Direction", direction, directionDampTime, Time.deltaTime );
	}

	public void ApplyMoveValue( Vector2 force )
	{
		if( isInLocomotion && ( ( direction >= 0 && force.x >= 0 ) || ( direction < 0 && force.x < 0 ) ) )
		{
			Vector3 newRotationY = new Vector3( 0f, rotationDegreePerSecond * ( force.x < 0f ? -1f : 1f), 0f );
			Vector3 rotationAmount = Vector3.Lerp( Vector3.zero, newRotationY, Mathf.Abs(force.x ) );
			Quaternion deltaRotation = Quaternion.Euler( rotationAmount * Time.deltaTime );
			this.transform.rotation = ( this.transform.rotation * deltaRotation );
		}

	}

	private void InputToWorldSpace( Vector2 input, Transform root, Transform pivot, ref float directionOut, ref float speedOut )
	{
		Vector3 rootDirection = root.forward;
		Vector3 pivotDirection = pivot.forward;
		pivotDirection.y = 0f;

		Vector3 inputDirection = new Vector3( input.x, 0, input.y );
		speedOut = inputDirection.sqrMagnitude;

		Quaternion referentialShift = Quaternion.FromToRotation( Vector3.forward, pivotDirection );

		Vector3 moveDirection = referentialShift * inputDirection;
		Vector3 axisSign = Vector3.Cross( moveDirection, rootDirection );

		float angleRootToMove = Vector3.Angle( rootDirection, moveDirection ) * (axisSign.y >= 0 ? -1f : 1f);

		angleRootToMove /= 180f;

		directionOut = angleRootToMove * directionSpeed;

	}


}
