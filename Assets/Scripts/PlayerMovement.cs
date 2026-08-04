using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
	private static readonly int walkHash = Animator.StringToHash("walk");
	private InputSystem_Actions inputSystemActions;
	private InputAction moveAction;
	public Rigidbody2D rigidbody2D;
	public Animator animator;
	public float speed = 8f;

	void Awake()
	{
		inputSystemActions = new InputSystem_Actions();
		moveAction = inputSystemActions.Player.Move;
		rigidbody2D = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	void OnEnable()
	{
		inputSystemActions.Player.Enable();
	}

	void OnDisable()
	{
		inputSystemActions.Player.Disable();
	}

	void FixedUpdate()
	{
		Vector2 moveValue = moveAction.ReadValue<Vector2>();
		Vector2 linearVelocity = moveValue*speed;
		rigidbody2D.linearVelocity = linearVelocity;

		animator.SetBool(walkHash, linearVelocity.magnitude != 0f);
		if ((linearVelocity.x > 0 && transform.localScale.x < 0) || (linearVelocity.x < 0 && transform.localScale.x > 0))
		{
			transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		}
	}
}