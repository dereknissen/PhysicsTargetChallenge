using UnityEngine;

public class ObstacleMovementVertical : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveDistance = 3f;
    public float moveSpeed = 2f;

    private Vector3 startPosition;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Projectile(Clone)")
        {
            Destroy(collision.gameObject);
        }
    }

    void Start()
    {
        // Store the obstacle's original position
        startPosition = transform.position;
    }

    void Update()
    {
        // Move up and down continuously
        float newY = Mathf.PingPong(Time.time * moveSpeed, moveDistance);

        transform.position = startPosition + new Vector3(0, newY, 0);
    }
}