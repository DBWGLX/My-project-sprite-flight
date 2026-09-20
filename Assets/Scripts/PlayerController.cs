using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    //火箭移动
    public float thrustForce = 1f;
    public float maxSpeed = 5f;
    Rigidbody2D rb;

    public GameObject BoosterFlame;//推进火焰

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // 推进特效
        if (Mouse.current.leftButton.wasPressedThisFrame){
            BoosterFlame.SetActive(true);
        }
        else if(Mouse.current.leftButton.wasReleasedThisFrame){
            BoosterFlame.SetActive(false);
        }

        //鼠标检测
        if(Mouse.current.leftButton.isPressed){

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);//当前坐标 直接读~

            //方向 转变
            Vector2 direction = (mousePos - transform.position).normalized;

            transform.up = direction;

            //推进
            rb.AddForce(direction * thrustForce);

            //限制最大速度
            if(rb.linearVelocity.magnitude > maxSpeed){
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }

            //Debug.Log("Mouse was pressed: " + mousePos);
        }


    }

    //碰撞
    void OnCollisionEnter2D(Collision2D collision){
        Destroy(gameObject);
    }

}
