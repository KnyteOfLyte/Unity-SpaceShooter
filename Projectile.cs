﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	[SerializeField]
	private WeaponType			_type;

	// This public property mases the fiel _type and takes action when is it set
	public WeaponType	type {
		get {
			return (_type);
		}
		set {
			SetType (value);
		}
	}

	void Awake () {
		// Test to see whether this has passed off screen every 2 seconds
		InvokeRepeating ("CheckOffScreen", 2f, 2f);
	}

	/*
	public void SetType ( WeaponType eType) {
		// Set the _type
		_type = eType;
		WeaponDefinition def = Main.GetWeaponDefinition (_type);
		GetComponent<Renderer>().material.color = def.projectileColor;
	}*/

	public void SetType( WeaponType eType ) {
		_type = eType;//set the type based on the weapon type
		WeaponDefinition def = Main.GetWeaponDefinition( _type );
	}

	void CheckOffScreen() {
		if (Utils.ScreenBoundsCheck (GetComponent<Collider>().bounds, BoundsTest.offScreen) != Vector3.zero) {
			Destroy (this.gameObject);
		}
	}
}
