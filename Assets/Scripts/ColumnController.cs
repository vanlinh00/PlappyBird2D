using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnController : Singleton<ColumnController>
{
    float disXColums = 3.2f;
    float disYColums = 0;

    void Awake()
    {
        base.Awake();
    }
    public void BornNewColumn()
    {
        Vector3 LastPosChild = transform.GetChild(transform.childCount - 1).position;
        disYColums = Random.Range(-1, 1);
        Vector3 newPosChild = new Vector3(LastPosChild.x + disXColums, disYColums, 0);
        GameObject newColumn = Instantiate(Resources.Load("Column", typeof(GameObject)), newPosChild, Quaternion.identity) as GameObject;
        newColumn.transform.parent = this.transform;
    }
}
