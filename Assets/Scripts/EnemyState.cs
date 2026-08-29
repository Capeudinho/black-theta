using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyState : MonoBehaviour
{
	private static readonly int idleHash = Animator.StringToHash("idle");
	private static readonly int walkHash = Animator.StringToHash("walk");
	private static readonly int attackHash = Animator.StringToHash("attack");
	private Animator animator;
	public EnemyStateType enemyStateType = EnemyStateType.Idle;

	public void Awake()
	{
		animator = GetComponent<Animator>();
	}

	public void ChangeState(EnemyStateType newEnemyStateType)
	{
		if (enemyStateType != newEnemyStateType)
		{
			enemyStateType = newEnemyStateType;
			animator.SetBool(idleHash, enemyStateType == EnemyStateType.Idle);
			animator.SetBool(walkHash, enemyStateType == EnemyStateType.Walk);
			animator.SetBool(attackHash, enemyStateType == EnemyStateType.Attack);
		}
	}
}

public enum EnemyStateType
{
	Idle,
	Walk,
	Attack
}