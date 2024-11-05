using System.Collections;
using UnityEngine;

public class FallingSquare : MonoBehaviour
{
    [SerializeField] private float _changeColorHeight = -5.0f; 

    [SerializeField] private Color _newColor = Color.red; 

    void Start()
    {
        StartCoroutine(CheckPosition());
    }

    private IEnumerator CheckPosition()
    {
        yield return new WaitUntil(() => transform.position.y < _changeColorHeight);

        GetComponent<SpriteRenderer>().color = _newColor; 
    }
}
