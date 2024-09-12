using UnityEngine;

public class ColliderSencer : MonoBehaviour, ISencer
{

    [SerializeField] private Tags _checkingTags;

    private bool _sencing;

    public bool CheckSencing() => _sencing;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        int id = collision.gameObject.GetInstanceID();
        if (ObjectManager.Instance.FindGameTag(id).HasTag(_checkingTags))
        {

            _sencing = true;

        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        int id = collision.gameObject.GetInstanceID();
        if (ObjectManager.Instance.FindGameTag(id).HasTag(_checkingTags))
        {

            _sencing = true;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        int id = collision.gameObject.GetInstanceID();
        if (ObjectManager.Instance.FindGameTag(id).HasTag(_checkingTags))
        {

            _sencing = false;

        }

    }

}
