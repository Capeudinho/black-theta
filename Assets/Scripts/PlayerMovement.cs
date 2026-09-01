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
	private Rigidbody2D rigidbody2D;
	public float speed = 8f;

	void Awake()
	{
		inputSystemActions = new InputSystem_Actions();
		moveAction = inputSystemActions.Player.Move;
		attackAction = inputSystemActions.Player.Attack;
		shootAction = inputSystemActions.Player.Shoot;
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
		Vector2 direction = moveAction.ReadValue<Vector2>().normalized;
		Vector2 linearVelocity = direction*speed;
		rigidbody2D.linearVelocity = linearVelocity;

		if (linearVelocity.magnitude != 0f && playerState.GetState() != PlayerStateType.Attack)
		{
			playerState.ChangeState(PlayerStateType.Walk);

			Vector3 localScale = parentTransform.localScale;
			if ((linearVelocity.x > 0 && localScale.x < 0) || (linearVelocity.x < 0 && localScale.x > 0))
			{
				parentTransform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
			}
		}
		else
		{
			playerState.ChangeState(PlayerStateType.Idle);
		}
	}

	public InputSystem_Actions GetInputActions()
	{
		return inputSystemActions;
	}
}