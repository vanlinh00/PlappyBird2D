using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiStartGame : MonoBehaviour
{
    [SerializeField] Button _startGame;

    private void Awake()
    {
        _startGame.onClick.AddListener(StartGame);
    }
    void StartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }    

}
