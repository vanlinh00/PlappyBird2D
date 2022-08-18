using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelGameOver : MonoBehaviour
{

    [SerializeField] Text _currentMark;
    [SerializeField] Text _maxMark;
    private void Awake()
    {
        _currentMark.text = GameManager._instance.GetCurrentMark().ToString();
        _maxMark.text = (GameManager._instance.GetCurrentMark()>GameManager._instance.GetMaxMark())? GameManager._instance.GetCurrentMark().ToString(): GameManager._instance.GetMaxMark().ToString();
    }

}
