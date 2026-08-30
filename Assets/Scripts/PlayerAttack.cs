using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	public BoxCollider2D hitbox;
    private GameObject enemy;
    public float knockback = 30f;

    void Awake()
    {
		hitbox.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
		{
			enemy = collision.gameObject;
            //knockback
		}
    }

    void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			enemy = null;
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
