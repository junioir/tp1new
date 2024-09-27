using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ship : MonoBehaviour
{
    [SerializeField] private GoRight _EscapeShip;

    [SerializeField] private float _Interval = 3f;
    private float _timer;
    [SerializeField] private GameObject _junior;
   

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

            if (_timer > _Interval)

        {        
                instantiate();

               _timer = 0;
        }

        }
   


    private void instantiate() 
    {
        int _yMin = 3;
        int _yMax = 6;
        float randomY = Random.Range(-_yMin, _yMax);

        Vector3 randomPosition = transform.position;

        GoRight EscapeShip = Instantiate(_EscapeShip,new Vector3(randomPosition.x,randomPosition.y+randomY,randomPosition.z),Quaternion.identity);

        EscapeShip.GoRightFunction();

        Destroy(EscapeShip.gameObject, 20f);

    }
}
