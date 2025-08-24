using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void OnEnable()
    {
        PlayerController.OnDead += Dead;
        ProtalWin.OnWin += Win;
    }
    private void OnDisable()
    {
        ProtalWin.OnWin -= Win;
        PlayerController.OnDead -= Dead;
    }
    private void Win()
    {
        Debug.Log("Ganaste");
    }
    private void Dead()
    {
        SceneManager.LoadScene("Game");
    }
}
