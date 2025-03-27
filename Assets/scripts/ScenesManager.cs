using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    [SerializeField] private bool _isPersistent;

    public static ScenesManager Instance => _instance;
    private static ScenesManager _instance = null;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(_instance.gameObject);
            return;
        }
        _instance = this;

        if (_isPersistent)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ChangeSceneTo(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
