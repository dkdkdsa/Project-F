using UnityEngine;

public class ScaleFlip : MonoBehaviour, IFlip
{

    [SerializeField] private Transform _flipTarget;

    public void Flip(Vector2 flipVec)
    {

        _flipTarget.transform.localScale = new Vector3(
            1,
            flipVec.x < 0 ? -1 : 1, 
            1);

    }

}
