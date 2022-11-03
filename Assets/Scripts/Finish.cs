using UnityEngine;

public class Finish : MonoBehaviour
{

    public AudioSource FinishAudio;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Snake snake))
        {
            snake.ReachFinish();
            FinishAudio.PlayDelayed(0.25f);

        }
}
    }
    
