using UnityEngine;

public class MissileController : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;


    private void FixedUpdate()
    {
        var direction = PlayerController.Instance.transform.position - transform.position;
        direction = direction.normalized; // uzunluk farketmeksizin 0 ile 1 arasinda

        var rotateAmount = Vector3.Cross(direction, transform.up).z;

        rigidbody.velocity = transform.up * (moveSpeed * Time.deltaTime);
        rigidbody.angularVelocity = -rotateAmount * (rotateSpeed * Time.deltaTime);
    }
}

