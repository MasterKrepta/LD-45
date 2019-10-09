using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField] GameObject CockpitSpawn;
    [SerializeField] GameObject RearSpawn;
    [SerializeField] GameObject CanopySpawn;

    [SerializeField] GameObject CockPit;
    [SerializeField] GameObject Rear;
    [SerializeField] GameObject Canopy;
    AudioSource audioSource;
    [SerializeField] AudioClip cockpit;
    [SerializeField] AudioClip rear;
    [SerializeField] AudioClip canopy;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    public void InstallPart(GameObject part){
        part.transform.position = Vector3.zero;
        if (part.name == "Cockpit") {
            audioSource.clip = cockpit;
            audioSource.Play();
             GameObject go = Instantiate(CockPit, CockpitSpawn.transform.position, CockpitSpawn.transform.rotation);
            go.transform.parent = CockpitSpawn.transform;
            go.GetComponent<Collider>().enabled = false;

            Destroy(part.gameObject);
            Events.OnCockpitAquired();

        }
        else if (part.name == "Rear") {
            audioSource.clip = rear;
            audioSource.Play();
            GameObject go = Instantiate(Rear, RearSpawn.transform.position, RearSpawn.transform.rotation);
            go.transform.parent = RearSpawn.transform;
            go.GetComponent<Collider>().enabled = false;

            Destroy(part.gameObject);
            Events.OnRearAquired();
        }
        else if (part.name == "Canopy") {
            audioSource.clip = canopy;
            audioSource.Play();
            GameObject go = Instantiate(Canopy, CanopySpawn.transform.position, CanopySpawn.transform.rotation);
            go.transform.parent = CanopySpawn.transform;
            go.GetComponent<Collider>().enabled = false;

            Destroy(part.gameObject);
            Events.OnCanopyAquired();

        }
    }
}
