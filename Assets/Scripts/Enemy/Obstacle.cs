using UnityEngine;


public class Obstacle : MonoBehaviour
{

    public float minSize = 0.5f;
    public float maxSize = 2.0f;

    //速度
    public float minSpeed = 50f;
    public float maxSpeed = 300f;

    //旋转
    public float maxSpinSpeed = 10f;

    //碰撞爆炸
    public GameObject bounceEffectPrefab;
    public CollisionEffectPool collisionEffectPool;

    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        collisionEffectPool = FindFirstObjectByType<CollisionEffectPool>();

        SetRandomSize();
        SetRandomMovement();
        SetRandomRotation();
    }

    public void Activate(){
        SetRandomSize();
        SetRandomMovement();
        SetRandomRotation();
    }
    void SetRandomSize()
    {
        float randomSize = Random.Range(minSize, maxSize);

        transform.localScale = Vector3.one * randomSize;
    }

    void SetRandomMovement()
    {
        float randomSpeed = Random.Range(minSpeed, maxSpeed);

        // 体积越大，速度越慢
        randomSpeed /= transform.localScale.x;

        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        rb.AddForce(randomDirection * randomSpeed);
    }

    void SetRandomRotation()
    {
        float randomTorque = Random.Range(-maxSpinSpeed, maxSpinSpeed);

        rb.AddTorque(randomTorque);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision){ //和谁碰
        Vector2 contactPoint = collision.GetContact(0).point;

        collisionEffectPool.GetEffect(contactPoint);
    }


}
