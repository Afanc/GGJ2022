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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
