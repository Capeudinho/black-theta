using UnityEngine;

public class EnemyDetectAttack : MonoBehaviour
{
    private GameObject player;

    private EnemyState enemyState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        enemyState = this.GetComponentInParent<EnemyState>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player is not null && enemyState.enemyStateType != EnemyStateType.Attack)
        {
            enemyState.ChangeState(EnemyStateType.Attack);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;            
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = null;            
        }
    }

}
