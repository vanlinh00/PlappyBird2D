using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] public float _speed;
    void Update()
    {
        ChangePosition();
    }
    void ChangePosition()
    {
        transform.position -= new Vector3(1, 0, 0) * Time.deltaTime * _speed;
    }
}
