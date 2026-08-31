using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerState : MonoBehaviour
{
	private static readonly int idleHash = Animator.StringToHash("idle");
	private static readonly int walkHash = Animator.StringToHash("walk");
	private static readonly int attackHash = Animator.StringToHash("attack");
	private Animator animator;
	public PlayerStateType playerStateType = PlayerStateType.Idle;

	public void Awake()
	{
		animator = GetComponent<Animator>();
	}

	public void ChangeState(PlayerStateType newPlayerStateType)
	{
		if (playerStateType != newPlayerStateType)
		{
			playerStateType = newPlayerStateType;
			animator.SetBool(idleHash, playerStateType == PlayerStateType.Idle);
			animator.SetBool(walkHash, playerStateType == PlayerStateType.Walk);
			animator.SetBool(attackHash, playerStateType == PlayerStateType.Attack);
		}
	}

	public PlayerStateType GetState()
	{
		return playerStateType;
	}
}

public enum PlayerStateType
{
	Idle,
	Walk,
	Attack
}