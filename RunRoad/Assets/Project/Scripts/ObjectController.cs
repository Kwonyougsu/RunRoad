using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 2f; // 자동차 속도
    private Vector3 moveDirection; // 이동 방향

    void Start()
    {
        // 초기 위치에 따라 이동 방향 설정
        if (transform.position.x < 0)
        {
            // 왼쪽에서 생성된 경우 오른쪽으로 이동
            moveDirection = Vector3.right;
        }
        else
        {
            // 오른쪽에서 생성된 경우 왼쪽으로 이동
            moveDirection = Vector3.left;
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // 화면 밖으로 나가면 오브젝트 삭제
        if (moveDirection == Vector3.left && transform.position.x < -10f ||
            moveDirection == Vector3.right && transform.position.x > 10f)
        {
            Destroy(gameObject);
        }
    }
}
