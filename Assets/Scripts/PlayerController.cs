using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PlayerController: MonoBehaviour
{
    public float moveSpeed;

    float xInput;
    float yInput;

    Rigidbody rb;

    int coinsCollected;

    public AudioClip coinSound; 
    private AudioSource audioSource;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical"); 

        if(transform.position.y <= -5f)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(xInput * moveSpeed, 0, yInput * moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            audioSource.PlayOneShot(coinSound);
            coinsCollected++;
            other.gameObject.SetActive(false);
        }

        if(coinsCollected >= 4)
        {

        }
    }

}
