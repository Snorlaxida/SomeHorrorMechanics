using UnityEngine;
using UnityEngine.UI;

public class RaycastStart : MonoBehaviour
{
    public Transform raypoint;
    public float usingDintant = 1.75f;
    RaycastHit hit;

    public Text info;

    public int keysCount = 0;
    public Text keysText;
    private AudioSource source;
    public AudioClip pickupClip;

    private void Start()
    {
        keysText.text = "0";
        source = GetComponent<AudioSource>();
    }
    void LateUpdate()
    {
        if (Physics.Raycast(raypoint.position, raypoint.forward, out hit, usingDintant))
        {
            if (hit.collider.tag == "Untagged")
            {
                info.text = null;
            }

            if (hit.collider.tag == "Door")
            {
                info.text = "Door";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    DoorScript door = hit.collider.GetComponent<DoorScript>();
                    door.Using(transform);
                }
            }

            if (hit.collider.tag == "Key")
            {
                info.text = "Key";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    keysCount++;
                    keysText.text = keysCount.ToString();
                    Destroy(hit.collider.gameObject);
                    source.Stop();
                    source.PlayOneShot(pickupClip);
                }

            }
        }
        else
        {
            info.text = null;
        }
    }
}
