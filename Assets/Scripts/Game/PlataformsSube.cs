using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlataformsSube : MonoBehaviour
{
    [SerializeField] private float alturaObjetivo = 5f;
    [SerializeField] private float velocidad = 2f;

    private Rigidbody rb;
    private bool subiendo = false;
    private Vector3 posicionInicial;
    private Vector3 posicionObjetivo;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; 
    }

    private void Start()
    {
        posicionInicial = transform.position;
        posicionObjetivo = posicionInicial + Vector3.up * alturaObjetivo;
    }

    private void FixedUpdate()
    {
        if (subiendo)
        {
            rb.MovePosition(Vector3.MoveTowards(rb.position, posicionObjetivo, velocidad * Time.fixedDeltaTime));
        }
    }

    public void Subir()
    {
        subiendo = true;
    }
}
