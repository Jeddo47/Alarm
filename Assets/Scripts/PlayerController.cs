using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _moveSpeed;

    private void Update()
    {
        Rotate();
        Move();
    }

    private void Rotate() 
    {
        float rotation = Input.GetAxis("Horizontal");
        transform.Rotate(_rotationSpeed * rotation * Time.deltaTime * Vector3.up);
    }

    private void Move()
    {
        float direction = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * direction * _moveSpeed * Time.deltaTime);
    }
}