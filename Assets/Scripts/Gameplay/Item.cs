using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.Gameplay
{
	public class Item : MonoBehaviour
	{

		public string Item_name;
		public string Stat_name;
		public float Stat_value;
		public int Is_active; 
		public int Is_selected;
		public int item_index; 

		void ToggleItem()
		{
			Is_active = 1 - Is_active;
			transform.position = new Vector2(transform.position.x, transform.position.y + (Is_active*2 - 1)*20.65f);
		}

		void In_Storage()
		{
			Is_active = 0;
		}

		bool is_in_storage()
		{
			return Is_active == 0; 
		}

		void SwitchItemSelection()
		{

		}

		// Start is called before the first frame update
		void Start()
		{
		}

		// Update is called once per frame
		void Update()
		{
			//print(transform.position.x);
			if (Input.GetButtonDown("ToggleItem")) print("fuckthishit");
			if (Input.GetButtonDown("ToggleItem") && Is_selected == 1) ToggleItem();
			if (Input.GetButtonDown("ToggleItem") && Is_selected == 1) print("sahiesahtneoiasouhi");
			if (Input.GetButtonDown("SwitchBtwnItems")) SwitchItemSelection();

		}
	}
}
