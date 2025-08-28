using UnityEngine;

[RequireComponent(typeof(Renderer))] 
public class RandomColorApplier : MonoBehaviour
{
    [SerializeField] private float _minColorValue = 0.4f;
    [SerializeField] private float _maxColorValue = 1f;
    
    private Renderer _objectRenderer;
    
    private void Awake()
    {
        _objectRenderer = GetComponent<Renderer>();
        ApplyRandomColor();
    }
    
    private void ApplyRandomColor()
    {
        if (_objectRenderer != null)
        {
            Color randomColor = new Color(
                Random.Range(_minColorValue, _maxColorValue),
                Random.Range(_minColorValue, _maxColorValue),
                Random.Range(_minColorValue, _maxColorValue)
            );
            
            _objectRenderer.material.color = randomColor;
        }
    }
}