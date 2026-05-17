using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Transform tr;
    Rigidbody2D rb;
    public float speed = 10.0f;
    void Awake()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Update is called once per frame

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); //a 일떄 -1, d 일때 1, 그외 0
        float v = Input.GetAxis("Vertical"); //w 일떄 1, s 일떄 -1, 그외 0 (우리 게임에서는 점프 외에는 y축 이동이 없으므로 v는 사용하지 않음)
        Move(h, 0); //a와 d키로 좌우 이동, y축 이동은 없으므로 0을 전달

    }

    void Move(float x, float y)
    {
        Vector2 p = (Vector2)tr.position + new Vector2(x, y) * speed * Time.deltaTime; //현재 위치에서 입력값과 속도, 프레임 시간을 곱해서 이동할 위치를 계산
        //Time.deltaTime -> move 함수가 void Update()에서 매 프레임마다 호출되므로, 컴퓨터가 좋아져 프레임이 높아질수록 이동이 빨라지는 것을 방지
        rb.MovePosition(p);
    }
}
