using UnityEngine;


public class Obstacle : MonoBehaviour
{

    public float minSize = 0.5f;
    public float maxSize = 3.0f;

    //速度
    public float minSpeed = 50f;
    public float maxSpeed = 300f;

    //旋转
    public float maxSpinSpeed = 10f;


    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //1.尺寸
        //随机数 min max
        float randomSize = Random.Range(minSize, maxSize);
        // 变换 尺寸： x y 倍数
        transform.localScale = new Vector3(randomSize,randomSize,1);

        // 2.加初始发射方向
        rb = GetComponent<Rigidbody2D>();

        float randomSpeed = Random.Range(minSpeed,maxSpeed);

        randomSpeed /= randomSize;//体积大 速度慢

        Vector2 randomDirection = Random.insideUnitCircle;

        rb.AddForce(randomDirection * randomSpeed);

        // 3.旋转
        float randomTorque = Random.Range(-maxSpinSpeed,maxSpinSpeed);
        rb.AddTorque(randomTorque);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
