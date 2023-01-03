using System;

public class Employe
{
	public string Name { get; private set; } 

	public int Age { get; private set; }

	public Employe(string name, int age)
	{
		Name = name;
		Age = age;
	}
}
