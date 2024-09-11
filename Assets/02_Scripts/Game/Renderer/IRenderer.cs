using Unity.Mathematics;
using UnityEngine;

public interface IRenderer
{

    public bool2 GetFlip();
    public void SetFlip(bool2 flip);
    public (float, float) GetSpriteSize();
    public void SetSpriteSize(float width, float height);
    void SetColor(int id, Color color);
}
