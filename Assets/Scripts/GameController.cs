using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public float speed;
    [SerializeField] TextMeshProUGUI scoreUI; 
    float score = 0;

  
    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        scoreUI.text = 0.ToString();
        StartCoroutine(IncreaseSpeed());
    }

    // Update is called once per frame
    void Update()
    {
        score += speed /2.5f * Time.deltaTime;
        scoreUI.text = ((int)score).ToString();
    }

    IEnumerator IncreaseSpeed()
    {  
        while(speed < 20)
        {
           
            yield return new WaitForSeconds(25);
            speed *= 1.1f;
        }
       
        
    }



    public void Replay()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
        
        Application.Quit();

        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; 
#endif
    }
}
