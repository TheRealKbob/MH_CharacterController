using UnityEngine;
using System.Collections;
using InControl;

public class InputBindings {

	public CharacterActions Actions{ get{ return actionSet; }}
	private CharacterActions actionSet;

	public InputBindings()
	{
		actionSet = new CharacterActions( null );

		bindMovementActions();
		bindCameraActions();
		bindPlayerActions();
		//I hate you kbob

	}

	private void bindMovementActions()
	{
		//LEFT
		actionSet.MoveLeft.AddDefaultBinding( Key.A );
		actionSet.MoveLeft.AddDefaultBinding( InputControlType.LeftStickLeft );

		//RIGHT
		actionSet.MoveRight.AddDefaultBinding( Key.D );
		actionSet.MoveRight.AddDefaultBinding( InputControlType.LeftStickRight );

		//FORWARD
		actionSet.MoveForward.AddDefaultBinding( Key.W );
		actionSet.MoveForward.AddDefaultBinding( InputControlType.LeftStickUp );

		//BACKWARD
		actionSet.MoveBackward.AddDefaultBinding( Key.S );
		actionSet.MoveBackward.AddDefaultBinding( InputControlType.LeftStickDown );
	}

	private void bindCameraActions()
	{
		//LEFT
		actionSet.LookLeft.AddDefaultBinding( Mouse.NegativeX );
		actionSet.LookLeft.AddDefaultBinding( InputControlType.RightStickLeft );

		//RIGHT
		actionSet.LookRight.AddDefaultBinding( Mouse.PositiveX );
		actionSet.LookRight.AddDefaultBinding( InputControlType.RightStickRight );

		//UP
		actionSet.LookUp.AddDefaultBinding( Mouse.PositiveY );
		actionSet.LookUp.AddDefaultBinding( InputControlType.RightStickUp );

		//LEFT
		actionSet.LookDown.AddDefaultBinding( Mouse.NegativeY );
		actionSet.LookDown.AddDefaultBinding( InputControlType.RightStickDown );

	}

	private void bindPlayerActions()
	{
		//Run
		actionSet.Run.AddDefaultBinding( Key.LeftShift );
		actionSet.Run.AddDefaultBinding( InputControlType.RightTrigger );
	}
	
}
