using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private Transform[] _layers; 
    [SerializeField] private float[] _parallaxScales; 
    [SerializeField] private float _smoothing = 1f; 

    private Transform _cam; 
    private Vector3 _previousCamPosition; 

    void Awake()
    {
        _cam = Camera.main.transform; 
    }

    void Start()
    {
        _previousCamPosition = _cam.position; 
        _parallaxScales = new float[_layers.Length];

        // Calculer les échelles de parallax
        for (int i = 0; i < _layers.Length; i++)
        {
            _parallaxScales[i] = _layers[i].position.y * -1; // Inverser la position pour le parallax
        }
    }

    void Update()
    {
        // Calculer le mouvement de la caméra
        Vector3 deltaMovement = _cam.position - _previousCamPosition;

        // Appliquer le parallax à chaque couche
        for (int i = 0; i < _layers.Length; i++)
        {
            float parallax = deltaMovement.y * _parallaxScales[i];
            Vector3 newLayerPosition = _layers[i].position;
            newLayerPosition.y += parallax;
            _layers[i].position = Vector3.Lerp(_layers[i].position, newLayerPosition, _smoothing * Time.deltaTime);
        }

        _previousCamPosition = _cam.position; // Mettre à jour la position précédente
    }
}