using UnityEngine;

public class SwordWeapon : MeleeWeaopnBase
{

    [SerializeField] private Transform _visualPivot;

    private IFlip _flip;

    public override void LocalInject(ComponentList list)
    {

        base.LocalInject(list);

        _flip = list.Find<IFlip>();

    }

    public override void DoAttack(object extraData = null)
    {

        var t = extraData.Cast<InputType>();

        if (t == InputType.Down)
        {

            _visualPivot.localScale = new Vector3(1, _visualPivot.localScale.y * -1, 1); //나중에 옮기기
            Casting();


        }

    }

    private void Casting()
    {

        AttackData data = new AttackData() { damage = Damage };

        var castings = Physics2D.OverlapBoxAll(
            transform.position + (transform.right * CastingSize.x), 
            CastingSize, _root.eulerAngles.z);

        if (castings.Length <= 0)
            return;

        SubSkills.Apply(ref data);

        foreach (var obj in castings)
        {

            var tag = ObjectManager.Instance.FindGameTag(obj.GetGameObjectId());

            if (tag != null && tag.HasTag(Tags.Hit))
                if (tag.TryGetComponent<IHitable>(out var compo))
                    compo.Hit(data);

        }

    }

    public override void Rotate(object extraData = null)
    {

        if (extraData == null)
            return;

        var rawVec = extraData.Cast<Vector2>();
        var vec = Camera.main.ScreenToWorldPoint(rawVec);
        vec.z = 0;

        var dir = vec - _root.position;
        _root.right = dir.normalized;
        _flip.Flip(dir.normalized);

    }

}
