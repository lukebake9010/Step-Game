using UnityEngine;

public class RandomMover : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float directionChangeInterval = 2f;

    private Vector2 moveDirection;
    private float directionChangeTimer;

    void Start()
    {
        PickNewDirection();
    }

    void Update()
    {
        // Move using Time.deltaTime (will be affected by timeScale)
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Countdown timer to change direction
        directionChangeTimer -= Time.deltaTime;
        if (directionChangeTimer <= 0f)
        {
            PickNewDirection();
        }
    }

    void PickNewDirection()
    {
        float angle = Random.Range(0f, 360f);
        moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
        directionChangeTimer = directionChangeInterval;
    }
}
