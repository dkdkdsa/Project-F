using System.Collections.Generic;

public class SubSkillContainer
{

    private List<ISubSkill> _subSkills = new();

    public void AddSubSkill(ISubSkill skill)
    {

        _subSkills.Add(skill);

    }

    public void RemoveSubSkill(ISubSkill skill)
    {

        _subSkills.Remove(skill);

    }

    public void Apply(ref AttackData data)
    {

        foreach (var skill in _subSkills)
            skill.Apply(ref data);

    }

}