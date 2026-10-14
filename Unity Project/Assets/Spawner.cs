using UnityEngine;
using System.Collections;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public float yOffset = 1f;

    private Vector3 areaSize;
    private Transform targetTransform;

    void Start()
    {
        targetTransform = transform.parent != null ? transform.parent : transform;

        Renderer rend = targetTransform.GetComponent<Renderer>();
        Collider col = targetTransform.GetComponent<Collider>();

        if (rend != null)
        {
            areaSize = rend.bounds.size;
        }
        else if (col != null)
        {
            areaSize = col.bounds.size;
        }
        else
        {
            areaSize = targetTransform.localScale * 10f;
        }

        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnCube();
            yield return new WaitForSeconds(1f);
        }
    }

    void SpawnCube()
    {
        if (cubePrefab == null)
        {
            Debug.LogWarning("Cube Prefab is not assigned in the Inspector!");
            return;
        }

        Vector3 randomPos = new Vector3(
            Random.Range(targetTransform.position.x - (areaSize.x / 2f), targetTransform.position.x + (areaSize.x / 2f)),
            targetTransform.position.y + yOffset,
            Random.Range(targetTransform.position.z - (areaSize.z / 2f), targetTransform.position.z + (areaSize.z / 2f))
        );

        Instantiate(cubePrefab, randomPos, Quaternion.identity);
    }
}
