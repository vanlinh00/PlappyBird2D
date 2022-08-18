using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundController;

public class Column : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            SoundController._instance.OnPlayAudio(SoundType.scored);
            GameManager._instance.CountMark();
            UiController._instance.SetMark();
            ColumnController._instance.BornNewColumn();
        }
    }
}
