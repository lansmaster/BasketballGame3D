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
}