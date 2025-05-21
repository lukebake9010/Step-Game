using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStep : MonoBehaviour
{
    public float stepDistance = 1f;
    public float stepSpeed = 5f;
    public float timeFadeSpeed = 5f;

    private bool isStepping = false;
    private Vector3 targetPosition;

    private float targetTimeScale = 0f;

    void Update()
    {
        // Smoothly fade timescale towards target
        Time.timeScale = Mathf.MoveTowards(Time.timeScale, targetTimeScale, timeFadeSpeed * Time.unscaledDeltaTime);
        Time.fixedDeltaTime = 0.02f * Time.timeScale;

        if (!isStepping)
        {
            // Example usage: simulate click providing a direction (replace with real input later)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Simulate a target direction for stepping
                Vector3 stepDirection = new Vector3(1, 0, 0); // Replace with direction towards mouse
                StartStep(stepDirection);
            }
        }
        else
        {
            // Move toward target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, stepSpeed * Time.unscaledDeltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                transform.position = targetPosition;
                isStepping = false;
                targetTimeScale = 0f; // Freeze time again
            }
        }
    }

    void StartStep(Vector3 direction)
    {
        targetPosition = transform.position + direction.normalized * stepDistance;
        isStepping = true;
        targetTimeScale = 1f; // Resume time
    }
}
