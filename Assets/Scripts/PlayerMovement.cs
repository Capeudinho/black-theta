using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	private Transform parentTransform;
	private PlayerState playerState;
	private InputSystem_Actions inputSystemActions;
	private InputAction moveAction;
	private InputAction attackAction;
	private InputAction shootAction;
	private InputAction dashAction;
	private Rigidbody2D rigidbody2D;
	public float speed = 8f;

	public float dashSpeed = 24f;
	public float dashDuration = 0.15f;
	public float dashCooldown = 0.6f;
	private bool isDashing = false;
	private float dashTimer = 0f;
	private float dashCooldownTimer = 0f;
	private Vector2 dashDirection;

	void Awake()
	{
		inputSystemActions = new InputSystem_Actions();
		moveAction = inputSystemActions.Player.Move;
		attackAction = inputSystemActions.Player.Attack;
		shootAction = inputSystemActions.Player.Shoot;
		dashAction = inputSystemActions.Player.Dash;
		parentTransform = transform.parent.GetComponent<Transform>();
		playerState = transform.parent.GetComponent<PlayerState>();
		rigidbody2D = transform.parent.GetComponent<Rigidbody2D>();
	}

	void OnEnable()
	{
		inputSystemActions.Player.Enable();
	}

	void OnDisable()
	{
		inputSystemActions.Player.Disable();
	}

    void Update()
    {
        if (dashCooldownTimer > 0f)
		{
			dashCooldownTimer -= Time.deltaTime;
		}

        if (dashAction.WasPressedThisFrame() && !isDashing && dashCooldownTimer <= 0f)
		{
			StartDash();
			return;
		}

		if (isDashing)
		{
			return;
		}

        if (attackAction.WasPressedThisFrame())
		{
			playerState.ChangeState(PlayerStateType.Attack);
		} else if (shootAction.WasPressedThisFrame())
		{
			playerState.ChangeState(PlayerStateType.Shoot);
		}
    }

    void FixedUpdate()
	{
		if (isDashing)
		{
			rigidbody2D.linearVelocity = dashDirection * dashSpeed;
			FaceDirection(dashDirection);

			dashTimer -= Time.fixedDeltaTime;
			if (dashTimer <= 0f)
			{
				isDashing = false;
			}
			return;
		}

		Vector2 direction = moveAction.ReadValue<Vector2>().normalized;
		Vector2 linearVelocity = direction*speed;
		rigidbody2D.linearVelocity = linearVelocity;

		if (linearVelocity.magnitude != 0f && playerState.GetState() != PlayerStateType.Attack)
		{
			playerState.ChangeState(PlayerStateType.Walk);
			FaceDirection(linearVelocity);
		}
		else
		{
			playerState.ChangeState(PlayerStateType.Idle);
		}
	}

	private void StartDash()
	{
		Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
		dashDirection = (mouseWorldPos - (Vector2)parentTransform.position).normalized;
		if (dashDirection == Vector2.zero)
		{
			dashDirection = parentTransform.localScale.x < 0 ? Vector2.left : Vector2.right;
		}

		isDashing = true;
		dashTimer = dashDuration;
		dashCooldownTimer = dashCooldown;
	}

	private void FaceDirection(Vector2 direction)
	{
		Vector3 localScale = parentTransform.localScale;
		if ((direction.x > 0 && localScale.x < 0) || (direction.x < 0 && localScale.x > 0))
		{
			parentTransform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
		}
	}

	public InputSystem_Actions GetInputActions()
	{
		return inputSystemActions;
	}
}