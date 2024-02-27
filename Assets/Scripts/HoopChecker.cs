using System;
using System.Collections;
using UnityEngine;

public class HoopChecker : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    public event Action BallHitted;

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
        BallHitted?.Invoke();
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        _particleSystem.Stop();
    }
}