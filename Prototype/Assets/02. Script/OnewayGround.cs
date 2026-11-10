using Unity.VisualScripting;
using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class OnewayGround : MonoBehaviour
{
    private TilemapCollider2D isCollision;

    // 인스펙터 창에서 플레이어의 Collider2D를 드래그해서 넣어주세요.
    [SerializeField] private Collider2D playerCollider; 
    
    // 콜라이더가 꺼져있을 시간 (플레이어가 발판을 완전히 통과할 시간)
    [SerializeField] private float disableTime = 0.44f; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isCollision = GetComponent<TilemapCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // 아래 키 또는 S키를 눌렀을 때 코루틴 실행
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (playerCollider != null)
            {
                StartCoroutine(PassThroughRoutine());
            }
        }
    }

    private IEnumerator PassThroughRoutine()
    {
        // 플레이어와 타일맵 사이의 충돌만 끔
        Physics2D.IgnoreCollision(playerCollider, isCollision, true);
        
        // 지정된 시간만큼 대기 (이 시간 동안 플레이어가 아래로 떨어짐)
        yield return new WaitForSeconds(disableTime);
        
        // 충돌 다시 활성화
        Physics2D.IgnoreCollision(playerCollider, isCollision, false);
    }
}
