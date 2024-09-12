using System.Collections.Generic;

public interface IStatContainer
{

    public Dictionary<int, Stat> Container { get; set; }

    #region Get
    public Stat GetStat(int key)
    {

        if (Container.TryGetValue(key, out Stat result))
        {

            return result;

        }

        return null;

    }

    public Stat GetStat(string key) => GetStat(key.GetHash());

    public float GetStatValue(int key, float defaultValue = default)
    {

        var stat = GetStat(key);

        if (stat != null)
        {

            return stat.Value;

        }

        return defaultValue;

    }

    public float GetStatValue(string key, float defaultValue = default) => GetStatValue(key.GetHash(), defaultValue);

    #endregion

    #region Add

    public void AddStat(int key, Stat stat)
    {

        Container.Add(key, stat);

    }

    public void AddStat(string key, Stat stat) => AddStat(key.GetHash(), stat);

    #endregion


    public Stat this[int key]
    {
        get 
        { 
        
            return Container[key];

        }

    }
}
