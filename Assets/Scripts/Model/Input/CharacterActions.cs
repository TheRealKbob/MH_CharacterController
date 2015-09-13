using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using InControl;

//Treat this as an ENUM with string values
public struct MovementActions
{
	public static string LEFT = "MOVE_LEFT";
	public static string RIGHT = "MOVE_RIGHT";
	public static string FORWARD = "MOVE_FORWARD";
	public static string BACKWARD = "MOVE_BACKWARD";
}

//Treat this as an ENUM with string values
public struct CameraActions
{
	public static string LEFT = "LOOK_LEFT";
	public static string RIGHT = "LOOK_RIGHT";
	public static string UP = "LOOK_UP";
	public static string DOWN = "LOOK_DOWN";
}

//Treat this as an ENUM with string values
public struct PlayerActions
{
	public static string RUN = "RUN";
}

public class CharacterActions : PlayerActionSet {

	private InputDevice device;

	#region WSAD / Left Controller Axis
	public PlayerAction MoveLeft;
	public PlayerAction MoveRight;
	public PlayerAction MoveForward;
	public PlayerAction MoveBackward;
	public PlayerTwoAxisAction Move;
	#endregion

	#region Mouse / Right Controller Axis
	public PlayerAction LookLeft;
	public PlayerAction LookRight;
	public PlayerAction LookUp;
	public PlayerAction LookDown;
	public PlayerTwoAxisAction Look;
	#endregion

	#region Player
	public PlayerAction Run;
	#endregion

	/// <summary>
	/// Initializes a new instance of the <see cref="CharacterActions"/> class.
	/// </summary>
	/// <param name="device">Device.</param>
	public CharacterActions( InputDevice device )
	{
		this.device = device;

		configureMovementActions();
		configureCameraActions();
		configurePlayerActions();
	}

	#region Configure Functions
	private void configureMovementActions()
	{
		MoveLeft = initializeAction( MovementActions.LEFT );
		MoveRight = initializeAction( MovementActions.RIGHT );
		MoveForward = initializeAction( MovementActions.FORWARD );
		MoveBackward = initializeAction( MovementActions.BACKWARD );
		Move = initializeAction( MoveLeft, MoveRight, MoveBackward, MoveForward );
	}

	private void configureCameraActions()
	{
		LookLeft = initializeAction( CameraActions.LEFT );
		LookRight = initializeAction( CameraActions.RIGHT );
		LookUp = initializeAction( CameraActions.UP );
		LookDown = initializeAction( CameraActions.DOWN );
		Look = initializeAction( LookLeft, LookRight, LookUp, LookDown );
	}

	private void configurePlayerActions()
	{
		Run = initializeAction( PlayerActions.RUN );
	}
	#endregion

	#region Initialize Action Functions
	private PlayerAction initializeAction( string type )
	{
		PlayerAction returnAction = CreatePlayerAction( type );
		if( device != null ) returnAction.Device = device;
		return returnAction;
	}

	private PlayerTwoAxisAction initializeAction( PlayerAction negX, PlayerAction posX, PlayerAction negY, PlayerAction posY )
	{
		PlayerTwoAxisAction returnAction = CreateTwoAxisPlayerAction( negX, posX, negY, posY );
		return returnAction;
	}
	#endregion

}
