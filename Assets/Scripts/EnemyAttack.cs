using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	public BoxCollider2D hitbox;
    private GameObject player;

    void Awake()
    {
		hitbox.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
		{
			player = collision.gameObject;
			Debug.Log($"Hit Player");
			//dano
			player.GetComponentInParent<PlayerHealth>().TakeDamage(2);
		}
    }

    void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			player = null;
		}
	}

    public void EnableHitbox()
	{
		hitbox.enabled = true;
	}

	public void DisableHitbox()
	{
		hitbox.enabled = false;
	}
}