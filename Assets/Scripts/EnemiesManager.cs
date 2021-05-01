using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    private const string TagPlayer = "Player";
    [SerializeField] private Transform _player;
    [SerializeField] private List<Enemy> _enemies;


    private void Reset()
    {
        _player = GameObject.FindGameObjectWithTag(TagPlayer).transform;
        _enemies = GameObject.FindObjectsOfType<Enemy>().ToList();

        foreach (var enemy in _enemies)
        {
            //enemy.Player = _player;
        }
    }

    private void Awake()
    {
        foreach (var enemy in _enemies)
        {
            //enemy.Player = _player;
        }
    }
}
