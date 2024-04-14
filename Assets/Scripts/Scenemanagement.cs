using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scenemanagement : MonoBehaviour
{
    public string scenename;
    public void changeScene()
    {
        SceneManager.LoadScene(scenename);
    }
}
