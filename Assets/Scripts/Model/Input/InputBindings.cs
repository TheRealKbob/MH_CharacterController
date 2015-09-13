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
	
}
