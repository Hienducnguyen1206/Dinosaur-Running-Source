using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerController.GameOver += OnGameOver;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    private void OnDestroy()
    {
        PlayerController.GameOver -= OnGameOver;
    }

    public void OnGameOver()
    {
        gameObject.SetActive(true);
    }
}
