using UnityEngine;

// 结束

public class PlayerController : MonoBehaviour
{
    public GameObject explosionEffect;
    public GameManager gameManager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        

        gameManager.ShowRestartButton();
        Destroy(gameObject);
    }
}