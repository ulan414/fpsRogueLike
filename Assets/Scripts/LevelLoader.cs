using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public GameObject FirstLevel;
    public GameObject SecondLevel;
    // Update is called once per frame
    public void LoadLevel()
    {
        //StartCoroutine(LoadTheLevel(SceneManager.GetActiveScene().buildIndex + 1));
        if (FirstLevel.activeSelf)
            StartCoroutine(LoadTheLevel("procedural"));
        else if(SecondLevel.activeSelf)
            StartCoroutine(LoadTheLevel("City"));

    }
    IEnumerator LoadTheLevel(string levelName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelName);
    }

}
