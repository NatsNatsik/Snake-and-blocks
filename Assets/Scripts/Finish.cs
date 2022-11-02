using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Snake snake))
        {
            snake.ReachFinish();

        }
}
    }
    
