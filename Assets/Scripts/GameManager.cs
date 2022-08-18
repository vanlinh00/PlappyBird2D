using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public int _currentMark = 0;

    private int _maxMark = 0;

    void Start()
    {
        Application.targetFrameRate = 60;
        DontDestroyOnLoad(this);
    }
    private void Awake()
    {
        base.Awake();
    }
   public void StartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void CountMark()
    {
        _currentMark += 1;
    }
    public void SetMark()
    {
        _currentMark = 0;
    }
    public int GetCurrentMark()
    {
        return _currentMark;
    }
    public int GetMaxMark()
    {
        _maxMark = PlayerPrefs.GetInt("maxMark", 0);
        return _maxMark;
    }

    public void SetMaxMark( int Value)
    {
        _maxMark = PlayerPrefs.GetInt("maxMark", 0);
        if (Value > _maxMark)
        {
            PlayerPrefs.SetInt("maxMark", Value);
        }    
      
    }
}
