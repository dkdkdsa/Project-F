using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteRendererProvider : MonoBehaviour, IRenderer
{

    private SpriteRenderer _renderer;

    private void Awake()
    {

        _renderer = GetComponent<SpriteRenderer>();

    }

    public bool2 GetFlip()
    {

        return new bool2(_renderer.flipX, _renderer.flipY);

    }

    public void SetFlip(bool2 flip)
    {

        _renderer.flipX = flip.x;
        _renderer.flipY = flip.y;

    }

    public (float, float) GetSpriteSize()
    {
        return (_renderer.size.x, _renderer.size.y);
    }

    public void SetSpriteSize(float width, float height)
    {
        _renderer.size = new Vector2(width, height);
    }

    public void SetColor(int id, Color color)
    {

        _renderer.material.SetColor(id, color);

    }
}
