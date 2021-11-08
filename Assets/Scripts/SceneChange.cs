using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public void ChangeScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }
}
