using UnityEngine;

public class CubeRotator : MonoBehaviour
{
    private Vector3 rotationSpeed;

    void Start()
    {
        rotationSpeed = new Vector3(Random.Range(15f, 60f), Random.Range(15f, 60f), Random.Range(15f, 60f));
    }

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}