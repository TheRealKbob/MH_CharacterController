using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {
	
	private InputBindings inputBindings;
	private CharacterLocomotion locomotion;
	private PlayerCamera camera;

	// Use this for initialization
	void Start () {
	
		inputBindings = new InputBindings();
		locomotion = GetComponent<CharacterLocomotion>() as CharacterLocomotion;
		locomotion.Init( inputBindings );

		camera = GameObject.FindObjectOfType<PlayerCamera>() as PlayerCamera;
		camera.Init( inputBindings.Actions );
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
