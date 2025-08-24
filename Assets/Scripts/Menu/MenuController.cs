using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    [SerializeField] private TMP_Text textMessage;


    void Update()
    {
        textMessage.alpha=  Mathf.PingPong(Time.time, 1f);
    }

}
