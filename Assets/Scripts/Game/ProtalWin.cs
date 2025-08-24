using System;
using UnityEngine;

public class ProtalWin : MonoBehaviour
{
    public static event Action OnWin;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnWin?.Invoke();
        }
    }
}
