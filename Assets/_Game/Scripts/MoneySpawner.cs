using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AP.ProgrammerGame
{
    public class MoneySpawner : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Vector3 _spawnZone;

        [SerializeField] private GameObject _moneyPrefab;

        private void Start()
        {

        }
    }
}