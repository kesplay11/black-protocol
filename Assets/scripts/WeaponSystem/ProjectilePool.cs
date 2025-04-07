using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField] private Projectile _projectile;

    [Header("Settings")]
    [SerializeField] private int _maxCapacity = 30;
    [SerializeField] private int _initCapacity = 10;

    private Queue<Projectile> _queue = new();

    public static ProjectilePool Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        for (int i = 0; i < _initCapacity; i++)
        {
            var projectile = Instantiate(_projectile);
            projectile.gameObject.SetActive(false);
            _queue.Enqueue(projectile);
        }
    }

    public Projectile Get()
    {
        Projectile projectile;

        if (_queue.Count > 0)
        {
            projectile = _queue.Dequeue();
        }
        else if (_queue.Count + 1 <= _maxCapacity)
        {
            projectile = Instantiate(_projectile);
        }
        else
        {
            Debug.LogWarning("Se alcanzó la capacidad máxima del pool de proyectiles.");
            return null;
        }

        projectile.gameObject.SetActive(true);
        return projectile;
    }

    public void Return(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
        _queue.Enqueue(projectile);
    }
}