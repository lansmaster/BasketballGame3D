using System.Collections;
using UnityEngine;

public class HoopChecker : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private void Start()
    {
        _particleSystem.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        _particleSystem.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        _particleSystem.Stop();
    }
}