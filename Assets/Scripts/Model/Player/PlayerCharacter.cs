using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {
	
	private InputBindings inputBindings;
	private CharacterLocomotion locomotion;

	// Use this for initialization
	void Start () {
	
		inputBindings = new InputBindings();
		locomotion = GetComponent<CharacterLocomotion>() as CharacterLocomotion;
		locomotion.Init( inputBindings );
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
