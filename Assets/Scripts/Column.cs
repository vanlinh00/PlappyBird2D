using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            GameManager._instance.CountMark();
            UiController._instance.SetMark();
            ColumnController._instance.BornNewColumn();
        }
    }
}
