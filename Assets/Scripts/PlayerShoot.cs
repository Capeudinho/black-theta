using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject point;
    public GameObject projectile; //prefab
    private Vector2 mousePos;

    void FixedUpdate()
    {
        //aim
        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        point.transform.right = (mousePos - (Vector2)transform.position).normalized;
        point.transform.position = (Vector2)this.gameObject.transform.position + (mousePos - (Vector2)transform.position).normalized*0.8f;
    }

    public void Shoot()
    {
        GameObject shot = Instantiate(projectile, point.transform.position, point.transform.rotation);
        shot.GetComponent<Rigidbody2D>().linearVelocity = point.transform.right * 13f;
    }
}
