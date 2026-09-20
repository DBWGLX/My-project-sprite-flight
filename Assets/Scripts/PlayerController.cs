using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


public class PlayerController : MonoBehaviour
{
    //火箭 移动
    public float thrustForce = 1f;
    public float maxSpeed = 5f;
    Rigidbody2D rb;

    public GameObject BoosterFlame;//推进火焰

    // 分数 计算 与 显示
    private float elapsedTime = 0f;

    private float score = 0f;

    public float scoreMultiplier = 10;

    public UIDocument uiDocument;

    private Label scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //玩家对象 物理性质
        rb = GetComponent<Rigidbody2D>();

        //分数面板初始化 query
        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
    }

    void updateMouse(){
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

            //推进 加速
            rb.AddForce(direction * thrustForce);

            //限制最大速度
            if(rb.linearVelocity.magnitude > maxSpeed){
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }

            //Debug.Log("Mouse was pressed: " + mousePos);
        }

    }

    void updateScore(){
        //时间
        elapsedTime += Time.deltaTime;
        
        //根据时间计算分数 取整
        score = Mathf.FloorToInt(elapsedTime * scoreMultiplier);

        scoreText.text = "Score: " + score;
        //Debug.Log("Elapsed time: " + elapsedTime);
    }

    // Update is called once per frame
    void Update()
    {
        updateMouse();
        updateScore();
    }

    //碰撞
    void OnCollisionEnter2D(Collision2D collision){
        Destroy(gameObject);
    }

}
