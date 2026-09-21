using UnityEngine;
using UnityEngine.InputSystem;

// 物理逻辑
// 移动逻辑

// 火焰特效

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float thrustForce = 1f;
    public float maxSpeed = 5f;

    [Header("Effects")]
    public GameObject boosterFlame;

    private Rigidbody2D rb;
    private Camera mainCamera;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main; // 缓存，避免每帧查找
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        var mouse = Mouse.current;
        if (mouse == null) return;

        // 推进器特效
        if (mouse.leftButton.wasPressedThisFrame)
            boosterFlame.SetActive(true);
        else if (mouse.leftButton.wasReleasedThisFrame)
            boosterFlame.SetActive(false);

        // 按住鼠标推进
        if (mouse.leftButton.isPressed)
        {
            //方向计算：
            //坐标系变化
            Vector3 mousePos = mainCamera.ScreenToWorldPoint(mouse.position.value);
            Vector2 direction = ((Vector2)mousePos - (Vector2)transform.position).normalized;

            transform.up = direction;
            rb.AddForce(direction * thrustForce);

            if (rb.linearVelocity.magnitude > maxSpeed)
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }
}