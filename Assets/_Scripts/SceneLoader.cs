using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    string[] scenes = {"_Scene_0", "_Scene_1", "_Scene_2"};

    public void LoadScene(int i) { SceneManager.LoadScene(scenes[i]); } 
}
