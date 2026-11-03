using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class OnewayGround : MonoBehaviour
{
    private TilemapCollider2D isCollision;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isCollision = GetComponent<TilemapCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            isCollision.enabled = false; // 아래 키 또는 ㄴ를 누르면 Collider 비활성화
        }
        else
        {
            isCollision.enabled = true; // 그 외 상황에서는 활성화
        }
    }
}
