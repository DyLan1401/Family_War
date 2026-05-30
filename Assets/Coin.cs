using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //tag Player moi nhat dc
        if (collision.CompareTag("Player"))
        {
            //add xu vao
            GameManager.instance.AddCoin(1);
           //dong xu bien mat
            Destroy(gameObject);
        }
    }
}
