using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Gameplay
{
	public class ItemManager : MonoBehaviour
	{
		public int whatever = 42;
		public List<string> items = new List<string>(){};
		public Item[] items_container;

		public void addItem(Item item)
		{
			items.Add(item.Item_name);
		}

		public void removeItem(Item item)
		{
			items.Remove(item.Item_name);
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

		void SwitchItemSelection(int direction)
		{
			int index = 0;
			for (; index < items_container.Length; index++)
			{
				if (items_container[index].Is_selected == 1)	
				{
					items_container[index].Is_selected = 0;
					int new_index = Math.Max(Math.Min(index - direction, items_container.Length-1), 0);
					items_container[new_index].Is_selected = 1;
					break;
				}
			}
			
		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetButtonDown("SwitchBtwnItems")) SwitchItemSelection((int) Input.GetAxis("SwitchBtwnItems"));
		}
	}
}
