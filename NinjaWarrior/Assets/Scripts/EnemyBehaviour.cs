using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Rigidbody2D rbEnemy;
    public float moveSpeed;
    public PlayerBehaviour health;

    private void Start()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
        health = GetComponent<PlayerBehaviour>();
    }

    public void FixedUpdate()
    {
        rbEnemy.velocity = Vector2.left * moveSpeed;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<Animator>().SetTrigger("dieTrigger");
            GetComponent<Collider2D>().enabled = false;
            moveSpeed = 1f;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<Animator>().SetTrigger("hitTrigger");
        moveSpeed = 0;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}