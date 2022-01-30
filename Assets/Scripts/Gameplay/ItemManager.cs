using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Gameplay
{
	public class ItemManager : MonoBehaviour
	{
		public int whatever = 42;
		public Dictionary<string, float> stats = new Dictionary<string, float>(){};
		public List<string> items = new List<string>(){};
		public Item[] items_container;

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
			items_container = UnityEngine.Object.FindObjectsOfType<Item>();
			
			foreach(Item i in items_container)
			{
				this.addItem(i);
			}

		}

		void SwitchItemSelection()
		{
			/*
			int index = 0;
			for (; index < items_container.Length; index++)
			{
				if (items_container[index].Is_selected == 1)	
				{
					items_container[index].Is_selected == 0;
					items_container[index + 1 %2] == 1;
					break;
				}
			}
			*/
		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetButtonDown("SwitchBtwnItems")) SwitchItemSelection();
		}
	}
}
