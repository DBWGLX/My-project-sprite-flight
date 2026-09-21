using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class PlayerController : MonoBehaviour
{
    //1.火箭 移动
    public float thrustForce = 1f;
    public float maxSpeed = 5f;
    Rigidbody2D rb;

    public GameObject BoosterFlame;//推进火焰

    //2.分数 计算 与 显示
    private float elapsedTime = 0f;

    private float score = 0f;

    public float scoreMultiplier = 10;

    public UIDocument uiDocument;

    private Label scoreText;

    //3.碰撞爆炸逻辑
    public GameObject explosionEffect;

    //4.重开
    public Button restartButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //玩家对象 物理性质
        rb = GetComponent<Rigidbody2D>();

        //面板 分数初始化 query
        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");

        //面板 重启按钮
        restartButton = uiDocument.rootVisualElement.Q<Button>("RestartButton");
        restartButton.style.display = DisplayStyle.None; //  隐藏
        restartButton.clicked += ReloadScene;// 点击 加到list里
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
        //特效
        Instantiate(explosionEffect, transform.position, transform.rotation);
        //飞船消失
        Destroy(gameObject);

        //重开
        restartButton.style.display = DisplayStyle.Flex;
    }

    void ReloadScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}//the final closing curly brace
