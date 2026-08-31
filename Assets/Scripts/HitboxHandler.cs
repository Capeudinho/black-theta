using UnityEngine;

public class HitboxHandler : MonoBehaviour
{
	public void EnableHitbox()
	{
		GetComponentInChildren<EnemyAttack>().EnableHitbox();
	}

	public void DisableHitbox()
	{
		GetComponentInChildren<EnemyAttack>().DisableHitbox();
	}
}
