using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    [SerializeField] Text bestScoreText;
    [SerializeField] InputField playerName;
    // Start is called before the first frame update
    public void Start(){

        ScoreManager.Instance.LoadScore();
        UpdateBestScoreText();
        

    }

    public void UpdateBestScoreText(){
            string bestName = ScoreManager.Instance.bestName;
            int bestScore = ScoreManager.Instance.bestScore;
            bestScoreText.text= "Best Score: "+bestName +" : "+ bestScore;
        
    }
    public void StartGame(){
        SceneManager.LoadScene(1);

    }

    public void QuitGame(){
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
                Application.Quit(); // original code to quit Unity player
        #endif

        //ScoreManager.Instance.SaveScore(); 

    }
    public void OnEndEdit()
    {
        ScoreManager.Instance.currentName = playerName.text;
    }
    
}
