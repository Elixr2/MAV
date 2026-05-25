using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Transform tr;
    Rigidbody2D rb;
    public float speed = 10.0f;
    public Vector2 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    void Awake()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        jump = new Vector2(0.0f, 2.0f);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Update is called once per frame

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); //a 일떄 -1, d 일때 1, 그외 0
        float v = Input.GetAxis("Vertical"); //w 일떄 1, s 일떄 -1, 그외 0 (우리 게임에서는 점프 외에는 y축 이동이 없으므로 v는 사용하지 않음)
        rb.linearVelocity = new Vector2(h * speed, rb.linearVelocity.y); //a와 d키로 좌우 이동, y축 이동은 없으므로 0을 전달
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
} 

    
