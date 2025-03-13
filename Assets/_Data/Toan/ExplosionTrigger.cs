﻿using UnityEngine;

public class ExplosionTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public GameObject explosionPrefab; // Gán Prefab vụ nổ ở Inspector

    /* private void OnTriggerEnter2D(Collider2D other)
     {
         if (other.CompareTag("Player")) // Nếu nhân vật chạm vào
         {
             GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
             Destroy(explosion, 0.5f); // Xóa vụ nổ sau 0.5 giây
             Destroy(gameObject); // Xóa đối tượng va chạm
         }
     }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Explode();
        }
    }

    private void Explode()
    {
        if (explosionPrefab != null) // Kiểm tra nếu Prefab tồn tại
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 0.5f); // Xóa hiệu ứng sau 0.5 giây
        }

        Destroy(gameObject); // Xóa đối tượng va chạm
    }
}
