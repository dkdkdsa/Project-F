using System.Collections.Generic;

public class ObjectManager : MonoSingleton<ObjectManager>
{

    private Dictionary<int, GameTag> _tagContainer = new();

    public void AddGameTag(int hash, GameTag tag)
    {

        _tagContainer.Add(hash, tag);

    }

    public void RemoveGameTag(int hash)
    {

        _tagContainer.Remove(hash);

    }

    public GameTag FindGameTag(int hash)
    {

        _tagContainer.TryGetValue(hash, out GameTag tag);

        return tag;

    }

}
