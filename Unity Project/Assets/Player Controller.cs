using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("Movement speed in units per second.")]
    public float moveSpeed = 5f;

    private Rigidbody rb;
    private Vector3 movementInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("No Rigidbody found on " + gameObject.name + "! Please add a Rigidbody component.");
        }
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        movementInput = new Vector3(moveX, 0f, moveZ).normalized;
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            Vector3 targetPosition = rb.position + movementInput * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(targetPosition);
        }
    }
}
