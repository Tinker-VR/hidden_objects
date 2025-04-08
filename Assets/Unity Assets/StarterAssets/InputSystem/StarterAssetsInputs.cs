using System;
using Tinker;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool interact;
		public bool isPaused;

		[Header("Movement Settings")]
		public bool analogMovement;

		// [Header("Mouse Cursor Settings")]
		// public bool cursorLocked = true;
		// public bool cursorInputForLook = true;

		private void OnEnable()
		{
			GameManager.OnEndGame += OnEndGame;
		}
		
		private void OnDisable()
		{
			GameManager.OnEndGame -= OnEndGame;
		}
		
		private void OnEndGame()
		{
			isPaused = true;
		}


#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			LookInput(value.Get<Vector2>());
			// if(cursorInputForLook)
			// {
			// 	LookInput(value.Get<Vector2>());
			// }
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnAttack(InputValue value)
		{
			InteractInput(value.isPressed);
		}

		public void OnPause(InputValue value)
		{
			InteractPause(value.isPressed);
		}
#endif


		private void Update()
		{
			Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
			Cursor.visible = isPaused;
		}
		
		public void MoveInput(Vector2 newMoveDirection)
		{
			if (isPaused)
			{
				move = Vector2.zero;
				return;
			}
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			if (isPaused)
			{
				look = Vector2.zero;
				return;
			}
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			if(isPaused)return;
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			if(isPaused)return;
			sprint = newSprintState;
		}

		public void InteractInput(bool newInteractState)
		{
			if(isPaused)return;
			interact = newInteractState;
		}
		

		public void InteractPause(bool newPauseState)
		{
			if (newPauseState)
			{
				isPaused = !isPaused;
				GameManager.OnPauseGame?.Invoke(isPaused);
			}
		}
		
	}
	
}