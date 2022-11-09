using System;
using System.Collections.Generic;

namespace TextBasedVentures
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
		public float _volume;
		private float _weight;
		private float _volumeMax { get; set; }
		private float _carryCapacity { get; set; }
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
		public float Volume { get; set; }
		public float CarryCapacity {
			get
			{
				float Max = _carryCapacity;
				foreach(IItem item in items.Values)
				{
					Max = item.CarryCapacity;
				}
				return Max;
			}
			set
			{
				_carryCapacity = 10f;
			}
				 }
		public float VolumeMax
		{
			get
			{
				float Max = _volumeMax;
				foreach (IItem item in items.Values)
				{
					Max = item.VolumeMax;
				}
				return Max;
			}
			set
			{
				_volumeMax = 10f;
			}
		}

		public ItemContainer()
		{
			items = new Dictionary<string, IItem>();
		}
		public void put(IItem item)
		{
			//CarryCapacity = 5f;
			//float currentWeight = 0f;
			

			items[item.Name] = item;
			//if (currentWeight + Weight > CarryCapacity)
			//{
				//Console.WriteLine("Too heavy!");
			//}
			//else if(currentWeight + item.Weight > CarryCapacity)
			//{
				//Console.WriteLine("Inventory got too heavy!");
			//}
			//else
			//{
				//items[item.Name] = item;
				//currentWeight = currentWeight + Weight;
				//item.CarryCapacity = item.CarryCapacity - item.Weight;
			//}
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
			string itemNames = "Scouted Items: \n";
			Dictionary<string, IItem>.KeyCollection keys = items.Keys;
			foreach(string itemName in keys)
			{
				itemNames += " " + items[itemName].ToString() + "\n";
			}
			return itemNames;
		}
		public string LongName()
		{
			return "blank";
		}
		override
		public string ToString()
		{
			return Name + ", Weight: " + Weight + "\nSell Value " + SellValue + " Buy Value " + BuyValue;
		}
	}
}
