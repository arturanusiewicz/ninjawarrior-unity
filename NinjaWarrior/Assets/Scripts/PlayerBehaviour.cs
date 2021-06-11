using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    Rigidbody2D rbPlayer;
    public float moveSpeed;
    public Animator animator;
    public Text scoreText;
    public static int score;
    public static bool die;
    public int speed = 0;
    

    private void Awake()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        TouchMove();
    }

    void TouchMove()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (touchPosition.x < 0)
            {
                //move left
                rbPlayer.velocity = Vector2.left * moveSpeed;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                animator.SetBool("runBool", true);
            }
            else
            {
                //move right
                rbPlayer.velocity = Vector2.right * moveSpeed;
                transform.rotation = Quaternion.Euler(0, 180f, 0);
                animator.SetBool("runBool", true);
            }
        }
        else
        {
            rbPlayer.velocity = Vector2.zero;
            animator.SetBool("runBool", false);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            animator.SetTrigger("hitTrigger");
            AddPoint();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            animator.SetTrigger("dieTrigger");
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("GameOver");
    }

    public void AddPoint()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public static void PauseGame()
    {
        Time.timeScale = 0;
    }
}

