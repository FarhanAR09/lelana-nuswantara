using UnityEngine;

public class MouseToCameraPosition : MonoBehaviour
{
    [Header("Target Camera")]
    public Camera targetCamera;

    [Header("Camera X Range")]
    public float minX = -5f;
    public float maxX = 5f;

    [Header("Camera Y Range")]
    public float minY = -3f;
    public float maxY = 3f;

    [Header("Optional Smoothing")]
    public float smoothSpeed = 0f; // 0 = no smoothing

    private void Update()
    {
        Vector3 mouse = Input.mousePosition;

        // Normalize mouse position (0–1)
        float tX = mouse.x / Screen.width;
        float tY = mouse.y / Screen.height;

        // Clamp for safety
        tX = Mathf.Clamp01(tX);
        tY = Mathf.Clamp01(tY);

        // Remap to camera bounds
        float camX = Mathf.Lerp(minX, maxX, tX);
        float camY = Mathf.Lerp(minY, maxY, tY);

        Vector3 targetPos = new Vector3(camX, camY, targetCamera.transform.position.z);

        if (smoothSpeed > 0f)
        {
            targetCamera.transform.position =
                Vector3.Lerp(targetCamera.transform.position, targetPos, Time.deltaTime * smoothSpeed);
        }
        else
        {
            targetCamera.transform.position = targetPos;
        }
    }
}
