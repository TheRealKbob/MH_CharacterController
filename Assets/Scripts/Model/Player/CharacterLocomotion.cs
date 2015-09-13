using UnityEngine;
using System.Collections;

public class CharacterLocomotion : MonoBehaviour {

	private InputBindings bindings;
	private CharacterActions actions;

	// Use this for initialization
	void Start () {
		
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
			if( actions.Move.IsPressed )
			{
				ApplyMoveValue( actions.Move.Value );
			}
		}
	}

	public void ApplyMoveValue( Vector2 force )
	{

	}
}
