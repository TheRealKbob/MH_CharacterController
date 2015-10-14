using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {
	
	private InputBindings inputBindings;
	private PlayerLocomotion locomotion;

	[SerializeField]
	private PlayerCamera camera;
	public PlayerCamera Camera{ get{ return camera; } }

	// Use this for initialization
	void Start () {
	
		inputBindings = new InputBindings();
		loadComponents();
	}

	void Update () {
		
		handleCamera();

	}

	void FixedUpdate () {

	}

	void LateUpdate () {
		
	}

	private void loadComponents()
	{
		if( camera == null )
			camera = GameObject.FindObjectOfType<PlayerCamera>() as PlayerCamera;
	}

	// Handles the camera functions each frame
	private void handleCamera()
	{
		if( camera )
		{

			 

		}
	}
	
}
