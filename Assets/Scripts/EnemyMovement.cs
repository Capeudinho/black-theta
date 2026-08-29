using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	private Transform parentTransform;
	private Transform playerTransform;
	private EnemyState enemyState;
	private Rigidbody2D rigidbody2D;
	public float speed = 2f;

	void Awake()
	{
		parentTransform = transform.parent.GetComponent<Transform>();
		enemyState = transform.parent.GetComponent<EnemyState>();
		rigidbody2D = transform.parent.GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		if (playerTransform != null)
		{
			enemyState.ChangeState(EnemyStateType.Walk);

			Vector2 direction = (playerTransform.position-parentTransform.position).normalized;
			Vector2 linearVelocity = direction*speed;
			rigidbody2D.linearVelocity = linearVelocity;

			Vector3 localScale = parentTransform.localScale;
			if ((linearVelocity.x > 0 && localScale.x < 0) || (linearVelocity.x < 0 && localScale.x > 0))
			{
				parentTransform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
			}
		}
		else
		{
			enemyState.ChangeState(EnemyStateType.Idle);

			rigidbody2D.linearVelocity = Vector2.zero;
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			playerTransform = collision.gameObject.transform;
		}
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			playerTransform = null;
		}
	}
}