using UnityEngine;

public class CollisionEffect : MonoBehaviour
{
    public float lifeTime = 1f;

    private CollisionEffectPool pool;

    public void Initialize(CollisionEffectPool pool)
    {
        this.pool = pool;
    }

    void OnEnable()
    {
        Invoke(nameof(ReturnToPool), lifeTime);//
    }

    void ReturnToPool()
    {
        pool.ReturnEffect(gameObject);
    }
}