using UnityEngine;
using System.Collections;


public enum ItemIDs: int {
	Gun ,
	Magnum ,
	Shotgun ,
	Grenades ,
	Razor ,  
	AK47 , 
	Laser ,
	Rocketlauncher ,
	Minigun
}

public class Item { 
	public int ID       {get;set;}
	public string name  {get;set;}
	public char type    {get;set;} // w for weapon , g for granade , r for razor   // TODO : make values more universal

	public Item(int ID, string name , char type) {
		this.ID   = ID;
		this.name = name;
		this.type = type;
	}
};

public class Weapon : Item {
	public int range        {get; set;} // 0 for low , 1 for medium , 2 for unlimeted 
	public int firerate     {get; set;} // -1 for 0.5 seconds delay , 0 for semiautomatic , 1 for automatic , 2 for rapid fire , 3 for continuous  // NOTE: Can be used: For negative numbers delay 0.5*FR for positive numbers FR bullets per second
	public bool spread      {get; set;}
	public bool penetration {get; set;}

	public Weapon(int ID, string name , char type, int range ,int firerate, bool spread, bool penetration) : base(ID,name,type) {
		this.range    = range;
		this.firerate = firerate;
		this.spread   = spread;
		this.penetration = penetration;
	}

};