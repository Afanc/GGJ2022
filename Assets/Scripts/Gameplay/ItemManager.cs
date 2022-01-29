using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	public string Item_name;
	public string Stat_name;
	public float Stat_value;

	public Item(string item_name, string stat_name, float stat_value)
	{
		Item_name = item_name;
		Stat_name = stat_name;
		Stat_value = stat_value;
	}

}

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
