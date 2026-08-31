using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	public BoxCollider2D hitbox;
    private GameObject enemy;
    private float knockback = 30f;

    void Awake()
    {
		hitbox.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
		{
			enemy = collision.gameObject;
            //knockback na próx. linha
			enemy.GetComponentInParent<Rigidbody2D>().AddForce((enemy.GetComponentInParent<Transform>().position - this.transform.position).normalized * knockback, ForceMode2D.Impulse);
			Debug.Log($"Hit Enemy, {knockback} knck");
			//dano
			enemy.GetComponentInParent<EnemyHealth>().TakeDamage(1);
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
