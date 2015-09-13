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

public class CharacterActions : PlayerActionSet {

	private InputDevice device;

	#region WSAD / Left Controller Axis
	public PlayerAction MoveLeft;
	public PlayerAction MoveRight;
	public PlayerAction MoveForward;
	public PlayerAction MoveBackward;
	
	public PlayerTwoAxisAction Move;
	#endregion

	/// <summary>
	/// Initializes a new instance of the <see cref="CharacterActions"/> class.
	/// </summary>
	/// <param name="device">Device.</param>
	public CharacterActions( InputDevice device )
	{
		this.device = device;
			
		MoveLeft = initializeAction( MovementActions.LEFT );
		MoveRight = initializeAction( MovementActions.RIGHT );
		MoveForward = initializeAction( MovementActions.FORWARD );
		MoveBackward = initializeAction( MovementActions.BACKWARD );
		Move = initializeAction( MoveLeft, MoveRight, MoveBackward, MoveForward );

	}

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

}
