using UnityEngine;
using UnityEngine.UI;

public class BarPowerController : MonoBehaviour
{
    private Image image;

    [SerializeField] private float duration = 2;
    public float currentDuration;
    public bool isFull;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        currentDuration = duration;
        isFull = true;
    }

    private void Update()
    {
        image.fillAmount = currentDuration / duration;

        if (!isFull)
        {
            currentDuration -= Time.deltaTime;
            if (currentDuration <= 0f)
            {
                currentDuration = 0f;
                isFull = false; 
            }
        }
        else
        {
            currentDuration += Time.deltaTime;
            if (currentDuration >= duration)
            {
                currentDuration = duration;
                isFull = true; 
            }
        }
    }

}