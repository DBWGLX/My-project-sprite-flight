using System.Collections.Generic;
using UnityEngine;

// 不能挂载到另一个对象上

// 突然有了20个。刚构造 就调用了回调归还

public class CollisionEffectPool : MonoBehaviour
{
    public GameObject effectPrefab;
    public int poolSize = 10;

    private Queue<GameObject> effectPool = new Queue<GameObject>();

    void Start()
    {
        CreatePool();
    }

    void CreatePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject effect = Instantiate(effectPrefab);

            effect.SetActive(false);

            CollisionEffect collisionEffect = effect.GetComponent<CollisionEffect>();

            collisionEffect.Initialize(this);

            //effectPool.Enqueue(effect);
        }

        Debug.Log("poolSize: " + effectPool.Count);
    }

    // 取一个碰撞特效
    public GameObject GetEffect(Vector2 position)
    {
        //Debug.Log("取特效前，池子数量：" + effectPool.Count);

        if (effectPool.Count == 0)
        {
            //Debug.Log("碰撞特效池已空");
            return null;
        }

        GameObject effect = effectPool.Dequeue();

        effect.transform.position = position;
        effect.transform.rotation = Quaternion.identity;

        effect.SetActive(true);

        //Debug.Log("取出一个，剩余：" + effectPool.Count);

        return effect;
    }

    // 回收碰撞特效
    public void ReturnEffect(GameObject effect)
    {
        // Debug.Log(
        //     "归还特效：" + effect.name +
        //     "，归还前：" + effectPool.Count
        // );

        effect.SetActive(false);

        effectPool.Enqueue(effect);

        //Debug.Log("归还后：" + effectPool.Count);
    }
}