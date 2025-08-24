using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] private float transitionTime;
    private Animator transitionAnimator;
    

    private void Awake()
    {
        transitionAnimator = GetComponentInChildren<Animator>();
    }
    public void LoadNextScene()
    { 
       StartCoroutine(SceneLoad(SceneManager.GetActiveScene().buildIndex + 1));
    }
     
    public IEnumerator SceneLoad(int sceneIndex)
    {
        transitionAnimator.SetTrigger("StartTransition");
       yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
