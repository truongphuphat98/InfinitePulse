using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LaunchScene : MonoBehaviour {


	void OnEnable () {
        if (gameObject.name == "SceneLauncher")
            SceneManager.LoadScene(0);
        if (gameObject.name == "SceneLauncher2")
            SceneManager.LoadScene(1);
        if (gameObject.name == "SceneLauncher3")
            SceneManager.LoadScene(2);
        if (gameObject.name == "SceneLauncher4")
            SceneManager.LoadScene(0);
    }
	

	void Update () {
	
	}
}
