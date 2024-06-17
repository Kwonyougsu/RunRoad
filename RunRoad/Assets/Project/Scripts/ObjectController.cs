using UnityEngine;

public class CarController : MonoBehaviour
{
    private float speed; // 자동차 속도
    private Vector3 moveDirection; // 이동 방향
    public GameObject explosionPrefab;

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
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            moveDirection = Vector3.right;
            
        }
        speed = Random.Range(1f, 10f);
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // 화면 밖으로 나가면 오브젝트 삭제
        if (moveDirection == Vector3.right && transform.position.x < -12f ||
            moveDirection == Vector3.right && transform.position.x > 10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            // 충돌한 자동차와 이 자동차 모두 폭발 효과와 함께 파괴
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Instantiate(explosionPrefab, collision.transform.position, Quaternion.identity);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            moveDirection = Vector2.zero;
        }
    }
}
