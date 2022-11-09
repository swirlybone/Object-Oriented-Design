using System;

namespace OODProject1
{
	public interface IShape
	{
		string Name { get; }
		float Perimeter { get; }
		float Area { get; }
		int Sides { get; }
		void draw();
	}
	public class Triangle : IShape
	{
		private string _name;
		public string Name { get { return _name; } }
		private float _perimeter;
		public float Perimeter { get { return Perimeter; } }
		public float _area;
		public float Area { get { return _area; } }
		public int Sides { get { return 3; } }
		public Triangle(string Name, float Perimeter, float Area)
		{
			_name = Name;
			_perimeter = Perimeter;
			_area = Area;
		}
		public void draw()
		{
			//Draw the triangle according to the points.
		}
	}

		public class Square : IShape
		{
			private string _name;
			public string Name { get { return _name; } }
			private float _perimeter;
			public float Perimeter { get { return _perimeter; } }
			public float _area;
			public float Area { get { return _area; } }
			public int Sides { get { return 4; } }
			public Square(string Name, float Perimeter, float Area)
			{
				_name = Name;
				_perimeter = Perimeter;
				_area = Area;
			}
			public void draw()
			{
				//Draw the square according to the points.
			}
		}
	}

