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
		// I hate you kbob
		// Hate you too, Ty<3

	}

	private void bindMovementActions()
	{
		bindDefault( actionSet.MoveLeft, Key.A, nputControlType.LeftStickLeft ); //LEFT 
		bindDefault( actionSet.MoveRight, Key.D, InputControlType.LeftStickRight ); //RIGHT
		bindDefault( actionSet.MoveForward, Key.W, InputControlType.LeftStickUp ); //FORWARD
		bindDefault( actionSet.MoveBackward, Key.S, InputControlType.LeftStickDown ); //BACKWARD
	}

	private void bindCameraActions()
	{
		bindDefault( actionSet.LookLeft, Mouse.NegativeX, InputControlType.RightStickLeft ); //LEFT
		bindDefault( actionSet.LookRight, Mouse.PositiveX, InputControlType.RightStickRight ); //RIGHT
		bindDefault( actionSet.LookUp, Mouse.PositiveY, InputControlType.RightStickUp ); //UP
		bindDefault( actionSet.LookDown, Mouse.NegativeY, InputControlType.RightStickDown ); //DOWN
	}

	private void bindPlayerActions()
	{
		bindDefault( actionSet.Run, Key.LeftShift, InputControlType.RightTrigger ); //Run
		bindDefault( actionSet.Target, Key.Tab, InputControlType.LeftTrigger ); //Target
	}

	// Creates a Default binding on an action for both mouse and controller inputs
	private void bindDefault( PlayerAction action, Mouse mouseInput, InputControlType controllerInput )
	{
		action.AddDefaultBinding( mouseInput );
		action.AddDefaultBinding( controllerInput );
	}
	
}
