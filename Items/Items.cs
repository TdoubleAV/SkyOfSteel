using Godot;
using System.Collections.Generic;


public class Items : Node
{
	public class Instance
	{
		public Items.TYPE Type = Items.TYPE.ERROR;
		public int Temperature = 0;
		public int Count = 1;
		public int UsesRemaining = 0;
		public string Description = "This item description is a bug and should not exists";

		public Instance(Items.TYPE TypeArg)
		{
			this.Type = TypeArg;
		}
	}


	public enum TYPE {ERROR, PLATFORM, WALL, SLOPE}

	public static Dictionary<TYPE, Mesh> Meshes = new Dictionary<TYPE, Mesh>();
	private static Dictionary<TYPE, Texture> Thumbnails = new Dictionary<TYPE, Texture>();

	Items()
	{
		if(Engine.EditorHint) {return;}

		foreach(Items.TYPE Type in System.Enum.GetValues(typeof(TYPE)))
		{
			Meshes.Add(Type, GD.Load<Mesh>($"res://Items/Meshes/{Type}.obj"));
			//Assume that every item has a mesh, will throw exception on game startup if not
		}

		foreach(TYPE Type in System.Enum.GetValues(typeof(TYPE)))
		{
			Thumbnails.Add(Type, GD.Load<Texture>($"res://Items/Thumbnails/{Type}.png"));
			//Assume that every item has a texture, will throw exception on game startup if not
		}
	}


	public static Texture Thumbnail(TYPE Type)
	{
		return Thumbnails[Type];
	}
}
