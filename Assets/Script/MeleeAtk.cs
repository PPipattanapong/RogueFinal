using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class MeleeAtk : MonoBehaviour
{
    [SerializeField] private int swordAttack = 10;

    public float followSpeed = 5f; // Adjust the speed of the weapon's movement
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // Get the mouse position in the world coordinates
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Ensure the weapon stays in the 2D plane

        // Calculate the direction towards the mouse
        Vector3 direction = mousePosition - transform.position;

        // Rotate the weapon to face the mouse direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Move the weapon towards the mouse position
        transform.position = Vector3.Lerp(transform.position, mousePosition, followSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            MonsterHP monsterHP = other.GetComponent<MonsterHP>();
            monsterHP.MonsterTakeDamage(swordAttack);
        }
    }
}