using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Gameplay
{
	public class ItemManager : MonoBehaviour
	{
		public Dictionary<string, float> stats = new Dictionary<string, float>(){};
		public List<string> items = new List<string>(){};
		public Item[] items_container;

		public ItemManager()
		{
			//Item bottes7lieues = new Item("bottes_de_7_lieues", "maxSpeed", 10);
			//this.addItem(bottes7lieues);
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
			var item_container = UnityEngine.Object.FindObjectsOfType<Item>();
			
			foreach(Item i in item_container)
			{
				this.addItem(i);
			}

		}

		// Update is called once per frame
		void Update()
		{
			
		}
	}
}
