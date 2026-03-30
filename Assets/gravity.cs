using UnityEngine;
using UnityEngine.InputSystem;

public class gravity : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        public float followspeed = 8f;

        public float leftLimit = -4f;
        public float rightLimit = 4f;
        public float topLimit = 4f;
        public float bottomLimit = -4f;

        private Rigidbody2D rd;
        private Camera mainCam;
}

    void FixedUpdate()
{
    if (Mouse.current == null || mainCam == null)
        return;
    Vector2 mouseScreenPos = Mouse.current.position.ReadValue();

    Vector3 mouseWorldPos = mainCam.ScreenToWorldPoint(
        new Vector3(mouseScreenPos.x, mouseScreenPos.y, -mainCam.transform.position.z)
    );

    float targetX = Mathf.Clamp(mouseWorldPos.x, leftLimit, rightLimit);
    float targetY = Mathf.Clamp(mouseWorldPos.y, bottomLimit, topLimit);

    Vector2 targetPosition = new Vector2(targetX, targetY);

    Vector2 newPosition = Vector2.Lerp(rb.position, targetPosition, followspeed * Time.fixedDetlaTime);
}
// Update is called once per frame
void Update()
    {
        
    }
}
