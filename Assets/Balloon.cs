using UnityEngine;
using UnityEngine.InputSystem;

public class Balloon : MonoBehaviour
{
    [Header("Settings")]
    public float speed = 2f;
    public float destroyY = 10f;
    public GameObject particleEffectPrefab;

    private Camera mainCam;
    private bool isPopped = false;
    private Collider2D col;

    void Start()
    {
        mainCam = Camera.main;

        col = GetComponent<Collider2D>();

        if (col == null)
        {
            Debug.LogWarning(gameObject.name + "에 Collider2D가 없습니다! 클릭이 안 될 수 있어요.");
        }
    }

    void Update()
    {
        if (isPopped) return;

        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.y > destroyY)
        {
            Destroy(gameObject);
            return;
        }

        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            CheckClick();
        }
    }

    void CheckClick()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Ray ray = mainCam.ScreenPointToRay(mousePos);
        
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            Pop();
        }
    }

    void Pop()
    {
        if (isPopped) return;
        isPopped = true;

        if (particleEffectPrefab != null)
        {
            Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}