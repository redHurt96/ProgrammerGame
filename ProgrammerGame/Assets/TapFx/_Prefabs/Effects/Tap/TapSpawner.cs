using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TapSpawner : MonoBehaviour
{
    [SerializeField] private ParticleSystem _tapEffectPrefab;
    [SerializeField] private float _tapCooldown = 1f;

    private List<ParticleSystem> _taps = new List<ParticleSystem>();

    private float timer;

    private void Awake()
    {
        StartSpawner();
    }

    public void StartSpawner()
    {
        enabled = true;
        timer = 1.0f;
    }

    public void StopSpawner()
    {
        enabled = false;
    }

    private void Update()
    {
        timer += Time.deltaTime / _tapCooldown;
        timer = Mathf.Clamp01(timer);

        if (timer.Equals(1.0f))
        {
            SpawnTapEffect();
            timer = 0.0f;
        }
    }

    private void SpawnTapEffect()
    {
        for (int i = 0; i < _taps.Count; i++)
        {
            if (!_taps[i].gameObject.activeSelf)
            {
                _taps[i].gameObject.SetActive(true);
                return;
            }
        }

        var newTap = Instantiate(_tapEffectPrefab, transform);
        _taps.Add(newTap);
    }
}
