using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] Transform leftWaypoint, rightWaypoint;
    [SerializeField] float moveSpeed;

    bool isMovingRight = true;

    private void Update()
    {
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        if (transform.position.x > rightWaypoint.position.x)
        {
            isMovingRight = false;
        }
        else if (transform.position.x < leftWaypoint.position.x)
        {
            isMovingRight = true;
        }

        if (isMovingRight == true)
        {
            transform.Translate(new Vector2(moveSpeed, 0) * Time.deltaTime);
        }
        else
        {
            transform.Translate(new Vector2(-moveSpeed, 0) * Time.deltaTime);
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


}
