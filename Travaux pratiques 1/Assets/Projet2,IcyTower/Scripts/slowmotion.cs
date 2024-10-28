using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowmotion : MonoBehaviour
{
    
    [SerializeField] private float _slowMotionFactor = 0.5f; 

    [SerializeField] private float _slowDuration = 2f; 
    private float _originalTimeScale;

    void Start()
    {
        
        _originalTimeScale = Time.timeScale;
    }

    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            StartCoroutine(SlowMotionEffect());
            Debug.Log("slow motion activate");
        }
    }

    private IEnumerator SlowMotionEffect()
    {
        
        Time.timeScale = _slowMotionFactor;

        Time.fixedDeltaTime = Time.timeScale * 0.02f; 

        
        yield return new WaitForSecondsRealtime(_slowDuration);

        
        Time.timeScale = _originalTimeScale;
        Time.fixedDeltaTime = Time.timeScale * 0.02f; 
    }
}
