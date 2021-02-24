using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool isMoving;

    public float panSpeed = 50f;
    public float panBorderThickness = 50f;

    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 60f;

    void Update()
    {
        //Camera Panning

        float mouseY = Input.mousePosition.y;
        float mouseX = Input.mousePosition.x;

        if (mouseX >= 0 && mouseX <= Screen.width && mouseY >= 0 && mouseY <= Screen.height)
        {
            if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness && transform.position.z < Screen.height)
            {
                transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness && transform.position.z > Screen.height)
            {
                transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
            {
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
            {
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
            }
        }

        // Camera Zoom

        Vector3 pos = transform.position;

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}
