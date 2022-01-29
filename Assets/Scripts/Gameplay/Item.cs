using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.Gameplay
{
	public class Item : MonoBehaviour
	{

		public Button button_1;
		public string Item_name;
		public string Stat_name;
		public float Stat_value;
		public int Is_active; 

		public Item(string item_name, string stat_name, float stat_value)
		{
			Item_name = item_name;
			Stat_name = stat_name;
			Stat_value = stat_value;
			Is_active = 0;
		}

		void On_Character()
		{
			Is_active = 1;
			transform.position = new Vector2(transform.position.x, transform.position.y + 10);
		}

		void In_Storage()
		{
			Is_active = 0;
		}

		bool is_in_storage()
		{
			return Is_active == 0; 
		}

		// Start is called before the first frame update
		void Start()
		{
			button_1.onClick.AddListener(On_Character);	
		}

		// Update is called once per frame
		void Update()
		{
			print(transform.position.x);
		}
	}
}
