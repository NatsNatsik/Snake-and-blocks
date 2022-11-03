using Assets.Scripts;
using UnityEngine;
using System.Collections;
using TMPro;

public class Cube : MonoBehaviour
{
    [SerializeField]
    Color[] colors;
    private Renderer _renderer;
    [SerializeField]
    float timeDelay = .5f;
    [SerializeField]
    int score = 0;

    public TextMeshPro textScore;

    [SerializeField]
    bool loop = false;

    public AudioSource BreakWallAudio;

    void Start()
    {
        _renderer = gameObject.GetComponent<Renderer>();
        StartCoroutine(ChangeColor(timeDelay));
    }

    IEnumerator ChangeColor(float delay)
    {
        score = Random.Range(0, colors.Length);
        _renderer.material.color = colors[score];
        score++;

        textScore.SetText(score.ToString());

        yield return new WaitForSeconds(delay);

        if (loop)
            StartCoroutine(ChangeColor(delay));
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.TryGetComponent(out Snake snakeHead))    
        {
            BreakWallAudio.Play();
            score--;
            textScore.SetText(score.ToString());
           
            if(score == 0)
            {
               Destroy(gameObject);
            }
        }
    }
    private void Awake()
    {
       
    }
}

