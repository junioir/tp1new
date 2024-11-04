using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _squarePrefab;

    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private float _spawnInterval = 1.0f;

    [SerializeField] private Button _startButton;

    [SerializeField] private Button _stopButton;

    private Coroutine spawnRoutine;

    void Start()
    {
        
        _startButton.onClick.AddListener(StartSpawning);

        _stopButton.onClick.AddListener(StopSpawning);
    }

    private IEnumerator SpawnSquares()
    {
        while (true)
        {
            Instantiate(_squarePrefab, _spawnPoint.position, Quaternion.identity);

            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    public void StartSpawning()
    {
        if (spawnRoutine == null)
        {
            spawnRoutine = StartCoroutine(SpawnSquares());
        }
    }

    public void StopSpawning()
    {
        if (spawnRoutine != null)
        {
            StopCoroutine(spawnRoutine);
            spawnRoutine = null;
        }
    }
}
