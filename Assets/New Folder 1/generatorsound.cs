using UnityEngine;

public class Generator : MonoBehaviour
{
    public bool playerInRange = false;
    public bool isOn = false;

    public float runTime = 10f;
    private float timer;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponentInChildren<AudioSource>();
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ToggleGenerator();
        }

        if (isOn)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                TurnOff();
            }
        }
    }

    void ToggleGenerator()
    {
        if (!isOn)
        {
            TurnOn();
        }
        else
        {
            TurnOff();
        }
    }

    void TurnOn()
    {
        isOn = true;
        timer = runTime;

        Debug.Log("Generator ON");

        // Play sound
        if (audioSource != null)
        {
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    void TurnOff()
    {
        isOn = false;

        Debug.Log("Generator OFF");

        // Stop sound
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}