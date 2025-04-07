using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField] private Projectile _projectile;

    [Header("Settings")]
    [SerializeField] private int _maxCapacity;
    [SerializeField] private int _initCapacity;

    private Queue<Projectile> _queue = new();

    public static ProjectilePool Instance;

    void Awake()
    {
        if (ProjectilePool.Instance != null)
        {
            Destroy(this);
            return;
        }
        
        Instance = this;
    }

    void Start()
    {
        // Inicializar la piscina de proyectiles con la capacidad inicial.
        for (int i = 0; i < _initCapacity; i++)
        {
            var projectile = Instantiate(_projectile);
            projectile.gameObject.SetActive(false);
            _queue.Enqueue(projectile);
        }
    }

    public Projectile Get()
    {
        if (_queue.Count > 0)
        {
            return _queue.Dequeue();
        }

        // Si no hay proyectiles disponibles, crear uno nuevo.
        var projectile = Instantiate(_projectile);
        projectile.gameObject.SetActive(false);
        return projectile;
    }

    public void Return(Projectile projectile)
{
    projectile.StopAllCoroutines(); // ← Detenemos cualquier corrutina activa
    projectile.gameObject.SetActive(false);
    _queue.Enqueue(projectile);
}

    void Update()
    {
        // Aquí puedes agregar la lógica para actualizar el estado de la piscina si es necesario.
    }
}
