using UnityEngine;

public class CarController : MonoBehaviour
{
    private float speed; // �ڵ��� �ӵ�
    private Vector3 moveDirection; // �̵� ����
    public GameObject explosionPrefab;

    void Start()
    {
        // �ʱ� ��ġ�� ���� �̵� ���� ����
        if (transform.position.x < 0)
        {
            // ���ʿ��� ������ ��� ���������� �̵�
            moveDirection = Vector3.right;
        }
        else
        {
            // �����ʿ��� ������ ��� �������� �̵�
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            moveDirection = Vector3.right;
            
        }
        speed = Random.Range(1f, 10f);
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // ȭ�� ������ ������ ������Ʈ ����
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
            // �浹�� �ڵ����� �� �ڵ��� ��� ���� ȿ���� �Բ� �ı�
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
