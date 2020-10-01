using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(CapsuleCollider))]
	[RequireComponent(typeof(Animator))]
	public class ThirdPersonCharacter : MonoBehaviour
	{
		[SerializeField] float m_MovingTurnSpeed = 360;
		[SerializeField] float m_StationaryTurnSpeed = 180;
		[SerializeField] float m_JumpPower = 12f;
		[Range(1f, 4f)] [SerializeField] float m_GravityMultiplier = 2f;
		[SerializeField] float m_RunCycleLegOffset = 0.2f; //specific to the character in sample assets, will need to be modified to work with others
		[SerializeField] float m_MoveSpeedMultiplier = 1f;
		[SerializeField] float m_AnimSpeedMultiplier = 1f;
		[SerializeField] float m_GroundCheckDistance = 0.1f;

		public Rigidbody m_Rigidbody;
		Animator m_Animator;
		public bool m_IsGrounded;
		float m_OrigGroundCheckDistance;
		const float k_Half = 0.5f;
		float m_TurnAmount;
		float m_ForwardAmount;
		Vector3 m_GroundNormal;
		float m_CapsuleHeight;
		Vector3 m_CapsuleCenter;
		CapsuleCollider m_Capsule;
		bool m_Crouching;

		int m_JumpCount = 0;
		float m_MaxChargeJumpDuration = 1.0f;
		bool m_ChargingJump = false;
		float m_currentChargeDuration = 0;
		public bool hasChangedOrientationRecently = false;
		public bool isBoosted = false;

		public AudioClip ChargeSFX;
		public AudioSource SFXPlayer;

		void Start()
		{
			m_Animator = GetComponent<Animator>();
			m_Rigidbody = GetComponent<Rigidbody>();
			m_Capsule = GetComponent<CapsuleCollider>();
			m_CapsuleHeight = m_Capsule.height;
			m_CapsuleCenter = m_Capsule.center;

			m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
			m_OrigGroundCheckDistance = m_GroundCheckDistance;
		}

		public void Move(Vector3 move, bool crouch, bool jump)
		{
			if (m_ChargingJump)
			{
				move /= 5;
				m_currentChargeDuration += Time.deltaTime;
				m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, m_Rigidbody.velocity.y / 5, m_Rigidbody.velocity.z);
			}
			// convert the world relative moveInput vector into a local-relative
			// turn amount and forward amount required to head in the desired
			// direction.
			if (move.magnitude > 1f) move.Normalize();
			move = transform.InverseTransformDirection(move);
			CheckGroundStatus();
			move = Vector3.ProjectOnPlane(move, Vector3.up);
			m_TurnAmount = Mathf.Atan2(move.x, move.z);
			m_ForwardAmount = move.z;

			ApplyExtraTurnRotation();

			// control and velocity handling is different when grounded and airborne:
			if (m_IsGrounded)
			{
				HandleGroundedMovement(crouch, jump);
			}
			else
			{
				HandleAirborneMovement(jump);
			}

			ScaleCapsuleForCrouching(crouch);
			PreventStandingInLowHeadroom();

			// send input and other state parameters to the animator
			UpdateAnimator(move);
		}


		void ScaleCapsuleForCrouching(bool crouch)
		{
			if (m_IsGrounded && crouch)
			{
				if (m_Crouching) return;
				m_Capsule.height = m_Capsule.height / 2f;
				m_Capsule.center = m_Capsule.center / 2f;
				m_Crouching = true;
			}
			else
			{
				Ray crouchRay = new Ray(m_Rigidbody.position + transform.TransformDirection(Vector3.up) * m_Capsule.radius * k_Half, transform.TransformDirection(Vector3.up));
				float crouchRayLength = m_CapsuleHeight - m_Capsule.radius * k_Half;
				if (Physics.SphereCast(crouchRay, m_Capsule.radius * k_Half, crouchRayLength, Physics.AllLayers, QueryTriggerInteraction.Ignore))
				{
					m_Crouching = true;
					return;
				}
				m_Capsule.height = m_CapsuleHeight;
				m_Capsule.center = m_CapsuleCenter;
				m_Crouching = false;
			}
		}

		void PreventStandingInLowHeadroom()
		{
			// prevent standing up in crouch-only zones
			if (!m_Crouching)
			{
				Ray crouchRay = new Ray(m_Rigidbody.position + transform.TransformDirection(Vector3.up) * m_Capsule.radius * k_Half, transform.TransformDirection(Vector3.up));
				float crouchRayLength = m_CapsuleHeight - m_Capsule.radius * k_Half;
				if (Physics.SphereCast(crouchRay, m_Capsule.radius * k_Half, crouchRayLength, Physics.AllLayers, QueryTriggerInteraction.Ignore))
				{
					m_Crouching = true;
				}
			}
		}


		void UpdateAnimator(Vector3 move)
		{
			// update the animator parameters
			m_Animator.SetFloat("Forward", m_ForwardAmount, 0.1f, Time.deltaTime);
			m_Animator.SetFloat("Turn", m_TurnAmount, 0.1f, Time.deltaTime);
			m_Animator.SetBool("Crouch", m_Crouching);
			m_Animator.SetBool("OnGround", m_IsGrounded);
			if (!m_IsGrounded)
			{
				m_Animator.SetFloat("Jump", m_Rigidbody.velocity.y);
			}

			// calculate which leg is behind, so as to leave that leg trailing in the jump animation
			// (This code is reliant on the specific run cycle offset in our animations,
			// and assumes one leg passes the other at the normalized clip times of 0.0 and 0.5)
			float runCycle =
				Mathf.Repeat(
					m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime + m_RunCycleLegOffset, 1);
			float jumpLeg = (runCycle < k_Half ? 1 : -1) * m_ForwardAmount;
			if (m_IsGrounded)
			{
				m_Animator.SetFloat("JumpLeg", jumpLeg);
			}

			// the anim speed multiplier allows the overall speed of walking/running to be tweaked in the inspector,
			// which affects the movement speed because of the root motion.
			if (m_IsGrounded && move.magnitude > 0)
			{
				m_Animator.speed = m_AnimSpeedMultiplier;
			}
			else
			{
				// don't use that while airborne
				m_Animator.speed = 1;
			}
		}


		void HandleAirborneMovement(bool jump)
		{
			// apply extra gravity from multiplier:
			Vector3 extraGravityForce = (Physics.gravity * m_GravityMultiplier) - Physics.gravity;
			m_Rigidbody.AddForce(extraGravityForce);

			if (transform.rotation.eulerAngles.z > -10 && transform.rotation.eulerAngles.z < 10)
				m_GroundCheckDistance = m_Rigidbody.velocity.y < 0 ? m_OrigGroundCheckDistance : 0.01f;
			else if (transform.rotation.eulerAngles.z > 80 && transform.rotation.eulerAngles.z < 100)
			{
				if (transform.rotation.eulerAngles.y > -10 && transform.rotation.eulerAngles.y < 10)
					m_GroundCheckDistance = m_Rigidbody.velocity.x > 0 ? m_OrigGroundCheckDistance : 0.01f;
				else if (transform.rotation.eulerAngles.y > 170 && transform.rotation.eulerAngles.y < 190)
					m_GroundCheckDistance = m_Rigidbody.velocity.x < 0 ? m_OrigGroundCheckDistance : 0.01f;
				else if (transform.rotation.eulerAngles.y > 80 && transform.rotation.eulerAngles.y < 100)
					m_GroundCheckDistance = m_Rigidbody.velocity.z < 0 ? m_OrigGroundCheckDistance : 0.01f;
				else if (transform.rotation.eulerAngles.y > 260 && transform.rotation.eulerAngles.y < 280)
					m_GroundCheckDistance = m_Rigidbody.velocity.z > 0 ? m_OrigGroundCheckDistance : 0.01f;
			}
			else if (this.transform.rotation.eulerAngles.z > 260 && this.transform.rotation.eulerAngles.z < 280)
			{
				if (this.transform.eulerAngles.y > -10 && this.transform.rotation.eulerAngles.y < 10)
					m_GroundCheckDistance = m_Rigidbody.velocity.x < 0 ? m_OrigGroundCheckDistance : 0.01f;
				else if (this.transform.eulerAngles.y > 260 && this.transform.rotation.eulerAngles.y < 280)
					m_GroundCheckDistance = m_Rigidbody.velocity.z < 0 ? m_OrigGroundCheckDistance : 0.01f;
				else if (this.transform.eulerAngles.y > 170 && this.transform.rotation.eulerAngles.y < 190)
					m_GroundCheckDistance = m_Rigidbody.velocity.x > 0 ? m_OrigGroundCheckDistance : 0.01f;
				else if (this.transform.eulerAngles.y > 80 && this.transform.rotation.eulerAngles.y < 100)
					m_GroundCheckDistance = m_Rigidbody.velocity.z > 0 ? m_OrigGroundCheckDistance : 0.01f;
			}
			else if (this.transform.rotation.eulerAngles.z > 170 && this.transform.rotation.eulerAngles.z < 190)
			{
				m_GroundCheckDistance = m_Rigidbody.velocity.y > 0 ? m_OrigGroundCheckDistance : 0.01f;
			}

			HandleGroundedMovement(false, jump);
		}

		void HandleGroundedMovement(bool crouch, bool jump)
		{
			// check whether conditions are right to allow a jump:
			//if (jump && !crouch && m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Grounded"))
			if (!m_ChargingJump && jump && m_JumpCount < 2)
			{
				m_ChargingJump = true;
				SFXPlayer.clip = ChargeSFX;
				SFXPlayer.Play();
			}
			else if (!jump && m_ChargingJump && !crouch)
			{
				float chargedJumpPower = 1 + Mathf.Min(m_currentChargeDuration, m_MaxChargeJumpDuration) * 0.5f;
				//m_Rigidbody.velocity *= m_JumpDistance;
				//Vector3 horizontalVel = Vector3.ProjectOnPlane(m_Rigidbody.velocity, transform.TransformDirection(Vector3.up));
				//float velMagnitude = horizontalVel.magnitude * (0.25f + Mathf.Min(m_currentChargeDuration, m_MaxChargeJumpDuration) * 6);
				m_Rigidbody.velocity *= 0;
				// jump!
				if (transform.rotation.eulerAngles.z > -10 && transform.rotation.eulerAngles.z < 10)
					m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, m_JumpPower * chargedJumpPower, m_Rigidbody.velocity.z);
				else if (transform.rotation.eulerAngles.z > 80 && transform.rotation.eulerAngles.z < 100)
				{
					if (transform.rotation.eulerAngles.y > -10 && transform.rotation.eulerAngles.y < 10)
						m_Rigidbody.velocity = new Vector3(-m_JumpPower * chargedJumpPower, m_Rigidbody.velocity.y, m_Rigidbody.velocity.z);
					else if (transform.rotation.eulerAngles.y > 170 && transform.rotation.eulerAngles.y < 190)
						m_Rigidbody.velocity = new Vector3(m_JumpPower * chargedJumpPower, m_Rigidbody.velocity.y, m_Rigidbody.velocity.z);
					else if (transform.rotation.eulerAngles.y > 80 && transform.rotation.eulerAngles.y < 100)
						m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, m_Rigidbody.velocity.y, m_JumpPower * chargedJumpPower);
					else if (transform.rotation.eulerAngles.y > 260 && transform.rotation.eulerAngles.y < 280)
						m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, m_Rigidbody.velocity.y, -m_JumpPower * chargedJumpPower);
				}
				else if (this.transform.rotation.eulerAngles.z > 260 && this.transform.rotation.eulerAngles.z < 280)
				{
					if (this.transform.eulerAngles.y > -10 && this.transform.rotation.eulerAngles.y < 10)
						m_Rigidbody.velocity = new Vector3(m_JumpPower * chargedJumpPower, m_Rigidbody.velocity.y, m_Rigidbody.velocity.z);
					else if (this.transform.eulerAngles.y > 260 && this.transform.rotation.eulerAngles.y < 280)
						m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, m_Rigidbody.velocity.y, m_JumpPower * chargedJumpPower);
					else if (this.transform.eulerAngles.y > 170 && this.transform.rotation.eulerAngles.y < 190)
						m_Rigidbody.velocity = new Vector3(-m_JumpPower * chargedJumpPower, m_Rigidbody.velocity.y, m_Rigidbody.velocity.z);
					else if (this.transform.eulerAngles.y > 80 && this.transform.rotation.eulerAngles.y < 100)
						m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, m_Rigidbody.velocity.y, -m_JumpPower * chargedJumpPower);
				}
				else if (this.transform.rotation.eulerAngles.z > 170 && this.transform.rotation.eulerAngles.z < 190)
				{
					m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, -m_JumpPower * chargedJumpPower, m_Rigidbody.velocity.z);
				}
				//m_Rigidbody.AddForce(transform.TransformDirection(Vector3.forward) * m_JumpDistance * velMagnitude);
				m_IsGrounded = false;
				m_Animator.applyRootMotion = false;
				m_GroundCheckDistance = 0.1f;
				m_JumpCount++;
				m_ChargingJump = false;
				m_currentChargeDuration = 0;
			}
		}

		void ApplyExtraTurnRotation()
		{
			// help the character turn faster (this is in addition to root rotation in the animation)
			float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);
			transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0, Space.Self);
		}


		public void OnAnimatorMove()
		{
			// we implement this function to override the default root motion.
			// this allows us to modify the positional speed before it's applied.
			if (m_IsGrounded && Time.deltaTime > 0)
			{
				Vector3 v = (m_Animator.deltaPosition * m_MoveSpeedMultiplier) / Time.deltaTime;

				// we preserve the existing y part of the current velocity.
				//v.y = m_Rigidbody.velocity.y;
				m_Rigidbody.velocity = v;
			}
		}


		void CheckGroundStatus()
		{
			RaycastHit hitInfo;
#if UNITY_EDITOR
			// helper to visualise the ground check ray in the scene view
			Debug.DrawLine(transform.position + (transform.TransformDirection(Vector3.up) * 0.1f),
				transform.position + (transform.TransformDirection(Vector3.up) * 0.1f) +
				(transform.TransformDirection(Vector3.down) * m_GroundCheckDistance), Color.green, 1);
#endif
			// 0.1f is a small offset to start the ray from inside the character
			// it is also good to note that the transform position in the sample assets is at the base of the character
			if (m_ChargingJump)
			{
				m_GroundNormal = transform.TransformDirection(Vector3.up);
				m_IsGrounded = true;
				isBoosted = false;
			}
			else
			{
				if (Physics.Raycast(transform.position + (transform.TransformDirection(Vector3.up) * 0.1f), transform.TransformDirection(Vector3.down), out hitInfo, m_GroundCheckDistance))
				{
					if (!hitInfo.collider.isTrigger)
					{
						m_GroundNormal = hitInfo.normal;
						m_IsGrounded = true;
						m_Animator.applyRootMotion = true;
						m_JumpCount = 0;
						isBoosted = false;
					}
				}
				else
				{
					m_IsGrounded = false;
					m_GroundNormal = transform.TransformDirection(Vector3.up);
					m_Animator.applyRootMotion = false;
				}
			}
		}
	}
}