using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class BarPowerController : MonoBehaviour
{
    private Image image;
    [SerializeField] private float duration = 2;
    private float currentDuration;
    public float Duration => currentDuration;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    private void Start()
    {
        currentDuration = duration;
    }
    private void Update()
    {
        image.fillAmount = currentDuration / duration;
    }

}
