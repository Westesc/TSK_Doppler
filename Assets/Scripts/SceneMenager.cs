using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenager : MonoBehaviour
{
    // Start is called before the first frame update
    public void changeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
