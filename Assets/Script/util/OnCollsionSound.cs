using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollsionSound : MonoBehaviour
{
    public GameObject target;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == target)
        {
            audioSource.Play();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject == target)
        {
            audioSource.Play();
        }
    }
}
