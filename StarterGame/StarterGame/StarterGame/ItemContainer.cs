using System;
using System.Collections.Generic;

namespace StarterGame
{
	public interface IItemContainer : IItem
	{
		void put(IItem item);
		IItem remove(string itemName);
		string contents();
	}
	public class ItemContainer : IItemContainer
	{
		private Dictionary<string, IItem> items;
		public string Name { get; set; }
		private float _weight;
		public float Weight {
			get
			{
				float tWeight = _weight;
				foreach(IItem item in items.Values)
				{
					tWeight += item.Weight;
				}
				return tWeight;
			}
			set
			{
				_weight = value;
			}
				}
		public float SellValue { get; set; }
		public float BuyValue { get; set; }

		public ItemContainer()
		{
			items = new Dictionary<string, IItem>();
		}
		public void put(IItem item)
		{
			items[item.Name] = item;
		}
		public IItem remove ( string itemName)
		{
			IItem item = null;
			items.Remove(itemName, out item);
			return item;
		}

		public void  AddDecorator(IItem decorator)
		{

		}

		public string contents()
		{
			string itemNames = "Items: \n";
			Dictionary<string, IItem>.KeyCollection keys = items.Keys;
			foreach(string itemName in keys)
			{
				itemNames += " " + items[itemName].ToString() + "\n";
			}
			return itemNames;
		}
		public string LongName()
		{
			return "To be implemented";
		}
		override
		public string ToString()
		{
			return Name + ", Weight: " + Weight + "\nSell Value " + SellValue + " Buy Value " + BuyValue;
		}
	}
}
