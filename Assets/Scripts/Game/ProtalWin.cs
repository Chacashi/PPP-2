using System;
using UnityEngine;

public class ProtalWin : MonoBehaviour
{
    public static event Action OnWin;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            OnWin?.Invoke();
        }
    }
}
