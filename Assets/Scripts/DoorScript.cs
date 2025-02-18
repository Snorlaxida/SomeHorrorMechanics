using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private bool isopen = false;
    private bool isready = true;
    private Animator animator;
    private AudioSource source;
    private bool wasOpened = false;
    public AudioClip opening;
    public AudioClip closing;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

    }


    public void Using(Transform playerTransform)
    {
        if (isready)
        {
            isready = false;

            if (isopen)
            {
                Closing();
            }
            else
            {
                Opening();
            }

            Invoke("Ready", 0.5f);
        }
    }
    private void Opening()
    {
        animator.SetInteger("state", wasOpened ? 1 : -1);
        isopen = true;
        source.PlayOneShot(opening);
    }

    private void Closing()
    {
        animator.SetInteger("state", wasOpened ? 0 : -2);
        isopen = false;
        wasOpened = !wasOpened;
        source.PlayOneShot(closing);
    }

    private void Ready()
    {
        isready = true;
    }
}
