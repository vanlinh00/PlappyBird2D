using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnTopAndDown : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            UiController._instance.GameOver();
        }
    }


}

