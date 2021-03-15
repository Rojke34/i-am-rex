using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public CharacterController2D controller;

	public float runSpeed = 40f;

	public bool touchLimit = false;

	float horizontalMovementSpeed = 0f;

	void FixedUpdate () {
		// Move our character
		if (touchLimit) {
			horizontalMovementSpeed = -1 * runSpeed;
		} else {
			horizontalMovementSpeed = 1 * runSpeed;
		}

		controller.Move(horizontalMovementSpeed * Time.fixedDeltaTime, false, false);
	}

	public void CheckTouchLimit() {
		touchLimit = !touchLimit;
	}
}
