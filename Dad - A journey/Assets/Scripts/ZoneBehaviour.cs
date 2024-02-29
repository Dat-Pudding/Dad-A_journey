using UnityEngine;

public class ZoneBehaviour : MonoBehaviour
{
    public AudioSource bgMusic;
    public AudioClip track1;
    public AudioClip track2;
    public GameObject boss;
    public bool hasBoss;
    public bool isInZone;

    private void Update()
    {
        if (hasBoss)
        {
            bgMusic.clip = track2 as AudioClip;

        }
        else
        {
            bgMusic.clip = track1 as AudioClip;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == boss)
        {
            hasBoss = true;
        }

        if (collision.transform.name == "EventPoint")
        {
            isInZone = true;
            ToggleMusic();
        }
        else
        {
            isInZone = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.name == "EventPoint")
        {
            isInZone = false;
            ToggleMusic();
        }
    }

    void ToggleMusic()
    {
        if (!isInZone)
        {
            bgMusic.Pause();
        }
        if (isInZone)
        {
            bgMusic.Play();
        }
    }
}
