using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    private float _disXwall = 4.67f;
    private void Start()
    {
        for(int i=0;i<100;i++)
        {
            BornWall();
        }    
    }
    void BornWall()
    {
        Vector3 LastPosChild = transform.GetChild(transform.childCount - 1).position;
        Vector3 newPosChild = new Vector3(LastPosChild.x + _disXwall, LastPosChild.y, 0);
        GameObject newWall = Instantiate(Resources.Load("Wall", typeof(GameObject)), newPosChild, Quaternion.identity) as GameObject;
        newWall.transform.parent = this.transform;
    }    

}
