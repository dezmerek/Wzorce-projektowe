using System;
using System.Collections.Generic;

namespace org.am061.java.patterns.creational
{
	using DesignPattern = org.am061.java.patterns.DesignPattern;


	public class Composite : DesignPattern
	{

		public interface Component
		{
			void render();

			Node add(Component element);
		}

		public class Leaf : Component
		{
			private readonly Composite outerInstance;


			internal string name;

			internal Leaf(Composite outerInstance, string name)
			{
				this.outerInstance = outerInstance;
				this.name = name;
			}

			public virtual void render()
			{
				Console.WriteLine(name + " rendering...");
			}

			public virtual Node add(Component element)
			{
				throw new System.NotSupportedException();
			}
		}

		public class Node : Component
		{
			private readonly Composite outerInstance;


			internal IList<Component> children = new List<Component>();
			internal string name;

			internal Node(Composite outerInstance, string name)
			{
				this.outerInstance = outerInstance;
				this.name = name;
			}

			public virtual void render()
			{
				Console.WriteLine(name + " starts rendering...");

				foreach (Component child in children)
				{
					child.render();
				}

				Console.WriteLine(name + " finishes rendering...");
			}

			public virtual Node add(Component element)
			{
				children.Add(element);
				return this;
			}
		}

		public virtual void run()
		{
			Node root = (new Node(this, "Root")).add(new Leaf(this, "Leaf 1.1")).add((new Node(this, "Leaf 2")).add(new Leaf(this, "Leaf 2.1")).add(new Leaf(this, "Leaf 2.2")).add(new Leaf(this, "Leaf 2.3"))).add((new Node(this, "Leaf 3")).add(new Leaf(this, "Leaf 3.1")).add(new Leaf(this, "Leaf 3.2")).add((new Node(this, "Leaf 3.3")).add(new Leaf(this, "Leaf 3.3.1"))));

			root.render();
		}
	}

}