using UnityEngine;

public class PlayerBullet : Bullet
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Work");
        Destroy(collision.gameObject);

        //if (collision.gameObject.TryGetComponent(out Bullet bullet))
        //{
        //    Debug.Log(bullet.gameObject.name);
        //    bullet.gameObject.SetActive(false);
        //    gameObject.SetActive(false);
        //}

        //if (collision.gameObject.TryGetComponent(out Enemy enemy))
        //{
        //    Debug.Log(bullet.gameObject.name);
        //    enemy.gameObject.SetActive(false);
        //    gameObject.SetActive(false);
        //}


    }
}
