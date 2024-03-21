using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 4f;
    public Transform target;
    public float fixedYPosition;
    public float leftBoundary;
    public float rightBoundary;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Check if the target is assigned
        if (target != null)
        {
            float targetX = target.position.x;

            // Clamp the target x position within the boundaries
            targetX = Mathf.Clamp(targetX, leftBoundary, rightBoundary);

            // Move the camera towards the target position
            Vector3 targetPosition = new Vector3(targetX, fixedYPosition, -10f);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
