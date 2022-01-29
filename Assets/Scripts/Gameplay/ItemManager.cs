using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
	Dictionary<string, float> stats = new Dictionary<string, float>(){};
	List<string> items = new List<string>(){};

	public ItemManager()
	{
	}
	
	public float getStat(string stat)
	{
		return stats[stat];
	}

	public void addItem(Item item)
	{
		items.Add(item.Item_name);
		if (! stats.ContainsKey(item.Stat_name))
		{
			stats.Add(item.Stat_name, item.Stat_value);
		}
		else 
		{
			stats[item.Stat_name] += item.Stat_value; 
		}
	}

	public void removeItem(Item item)
	{
		items.Remove(item.Item_name);
		stats[item.Stat_name] -= item.Stat_value;
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
