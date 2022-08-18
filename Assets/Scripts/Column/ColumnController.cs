using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnController : Singleton<ColumnController>
{
   private float _disXColums = 3.2f;
   private float _disYColums = 0;

    void Awake()
    {
        base.Awake();
    }
    public void BornNewColumn()
    {
        Vector3 LastPosChild = transform.GetChild(transform.childCount - 1).position;
        _disYColums = Random.Range(-1, 1);
        Vector3 newPosChild = new Vector3(LastPosChild.x + _disXColums, _disYColums, 0);
        GameObject newColumn = Instantiate(Resources.Load("Column", typeof(GameObject)), newPosChild, Quaternion.identity) as GameObject;
        newColumn.transform.parent = this.transform;
    }
}
