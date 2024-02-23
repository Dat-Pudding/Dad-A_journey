using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public HotBarBehaviour hotBar;
    public Camera playerCam;
    public Transform shoulderTransform;
    public Transform handTransform;

    Quaternion angleCompound;
    Vector2 aimDirection;
    Vector2 mouseWorldPos;
    float rotationAngle;

    void Update()
    {
        mouseWorldPos = playerCam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        aimDirection = mouseWorldPos - new Vector2(shoulderTransform.position.x, shoulderTransform.position.y);
        rotationAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        angleCompound.eulerAngles = new Vector3(0, 0 , rotationAngle);
        shoulderTransform.rotation = angleCompound;
    }
}