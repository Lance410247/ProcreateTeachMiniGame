using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int sceneNumber=0 ;


    public void LoadNextScene() {

        SceneManager.LoadScene(sceneNumber);
    
    }



}
