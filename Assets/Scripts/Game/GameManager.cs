using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void OnEnable()
    {
        PlayerController.OnDead += Dead;
    }
    private void OnDisable()
    {
        PlayerController.OnDead -= Dead;
    }
    private void Dead()
    {
        SceneManager.LoadScene("Game");
    }
}
