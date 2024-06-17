using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 2f; // �ڵ��� �ӵ�
    private Vector3 moveDirection; // �̵� ����

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
            moveDirection = Vector3.left;
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // ȭ�� ������ ������ ������Ʈ ����
        if (moveDirection == Vector3.left && transform.position.x < -10f ||
            moveDirection == Vector3.right && transform.position.x > 10f)
        {
            Destroy(gameObject);
        }
    }
}
