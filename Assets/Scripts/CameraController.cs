using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool isMoving;

    public float panSpeed = 50f;
    public float panBorderThickness = 50f;

    public float scrollSpeed = 5f;
    public Vector2 panLimit;

    public float minY = 20f;
    public float maxY = 120f;

    void Update()
    {
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        //Camera Panning

        Vector3 pos = transform.position;

        float mouseY = Input.mousePosition.y;
        float mouseX = Input.mousePosition.x;

        if (mouseX >= 0 && mouseX <= Screen.width && mouseY >= 0 && mouseY <= Screen.height)
        {
            if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThickness)
            {
                pos.z += panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness)
            {
                pos.z -= panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness)
            {
                pos.x += panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThickness)
            {
                pos.x -= panSpeed * Time.deltaTime;
            }
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);
        
        transform.position = pos;
    }
}
