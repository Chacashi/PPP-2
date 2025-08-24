using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlataformsCae : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.useGravity = false;
        rb.isKinematic = true;
    }
    public void Caer()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
    }
                
}
