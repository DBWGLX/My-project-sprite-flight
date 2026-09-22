using System.Collections.Generic;
using UnityEngine;

public class GameChallenger : MonoBehaviour
{
    [Header("Obstacle")]
    public GameObject obstaclePrefab;

    [Header("Object Pool")]
    public int poolSize = 20;

    [Header("Spawn")]
    public float spawnInterval = 1f;

    // 四个生成点
    public Transform[] spawnPoints;

    // 对象池
    private Queue<GameObject> obstaclePool = new Queue<GameObject>();

    void Start()
    {
        CreatePool();

        InvokeRepeating(nameof(SpawnObstacle), 0f, spawnInterval);
    }

    // 创建对象池
    void CreatePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obstacle = Instantiate(obstaclePrefab);

            obstacle.SetActive(false);

            obstaclePool.Enqueue(obstacle);
        }
    }

    // 每秒调用一次
    void SpawnObstacle()
    {
        // 没有可用障碍物
        if (obstaclePool.Count == 0)
        {
            //Debug.Log("没有可用的 Obstacle");
            return;
        }

        // 随机选择一个生成点
        int index = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[index];

        // 从对象池取出
        GameObject obstacle = obstaclePool.Dequeue();

        obstacle.transform.position = spawnPoint.position;
        obstacle.transform.rotation = Quaternion.identity;

        obstacle.SetActive(true);
    }

    // 将障碍物放回对象池
    public void ReturnObstacle(GameObject obstacle)
    {
        obstacle.SetActive(false);

        obstaclePool.Enqueue(obstacle);
    }
}