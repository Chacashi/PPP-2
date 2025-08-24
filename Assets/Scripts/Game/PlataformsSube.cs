using UnityEngine;

public class PlataformsSube : MonoBehaviour
{
    [SerializeField] private float alturaObjetivo = 5f;
    [SerializeField] private float velocidad = 2f;

    private bool subiendo = false;
    private Vector3 posicionInicial;
    private Vector3 posicionObjetivo;

    private void Start()
    {
        posicionInicial = transform.position;
        posicionObjetivo = posicionInicial + Vector3.up * alturaObjetivo;
    }

    private void Update()
    {
        if (subiendo)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionObjetivo, velocidad * Time.deltaTime);
        }
    }

    public void Subir()
    {
        subiendo = true;
    }
}
