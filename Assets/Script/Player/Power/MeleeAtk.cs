using UnityEngine;

public class MeleeAtk : MonoBehaviour
{
    [SerializeField] private int swordAttack = 10;
    [SerializeField] private float followSpeed = 5f;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        UpdateRotationAndMovement();
    }

    private void UpdateRotationAndMovement()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        transform.position = Vector3.Lerp(transform.position, mousePosition, followSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HandleCollision(other);
    }

    private void HandleCollision(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            MonsterHP monsterHP = other.GetComponent<MonsterHP>();
            monsterHP?.MonsterTakeDamage(swordAttack);
        }
    }
}
