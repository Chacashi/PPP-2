using System.Collections;
using UnityEngine;

public class GravityPlayer : MonoBehaviour
{
    [Header("Characteristic")]
    [SerializeField] private float maxgravity = -20f;
    [SerializeField] private float mingravity = 9.81f;
    [SerializeField] private float duration = 2f;

    [Header("PlayerController Data")]
    private PlayerController playerController;

    private Coroutine gravityCoroutine;

    private void OnEnable()
    {
        InputReader.OnInputE += ActivateMinGravity;
        InputReader.OnInputQ += ActivateMaxGravity;
    }

    private void OnDisable()
    {
        InputReader.OnInputE -= ActivateMinGravity;
        InputReader.OnInputQ -= ActivateMaxGravity;
    }

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void ActivateMaxGravity()
    {
        HandleGravityInput(maxgravity);
    }

    public void ActivateMinGravity()
    {
        HandleGravityInput(mingravity);
    }

    private void HandleGravityInput(float newGravity)
    {
        if (gravityCoroutine != null)
        {
            StopCoroutine(gravityCoroutine);
            gravityCoroutine = null;

            playerController.gravity = -9.81f;
            return; 
        }

        gravityCoroutine = StartCoroutine(ChangeGravityCoroutine(newGravity, duration));
    }

    private IEnumerator ChangeGravityCoroutine(float newGravity, float time)
    {
        playerController.gravity = newGravity;
        yield return new WaitForSeconds(time);

        playerController.gravity = -9.81f;
        gravityCoroutine = null;
    }
}
