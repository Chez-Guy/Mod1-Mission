using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    TextMeshPro tmp;
    ScoreManager sm;

    void Start(){
        tmp = GetComponent<TextMeshPro>();
        sm = GameObject.Find("GameController").GetComponent<ScoreManager>();  
        UpdateScore();
    }

    public void UpdateScore(){tmp.text = "Score: "+sm.Score.ToString();}
}
