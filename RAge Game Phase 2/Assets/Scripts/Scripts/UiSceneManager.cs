using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiSceneManager : MonoBehaviour
{

    public Button buttonToChangeUiScene;

    public string sceneName;

    // Use this for initialization
    void Start()
    {
        buttonToChangeUiScene.onClick.AddListener(ChangeSceneToSettings);
    }

    void ChangeSceneToSettings()
    {
        print("Load new UI scene ");
        SceneManager.LoadScene(sceneName);
    }
}

  
