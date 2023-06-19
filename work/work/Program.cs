using System;

public class Test
{
	public static void Main()
	{
		
		string str = "Hello world! ";

		//	str = str.Replace("o", "*");

		Console.WriteLine(str);

		char[] strchar = new char[str.Length]; //str.ToCharArray();

		for (int i = 0; i < str.Length; i++)
		{
			strchar[i] = str[i];
		}


		for (int i = 0; i < str.Length; i++)
		{
			if (strchar[i] == 'o')
				strchar[i] = '*';

		}

		Console.WriteLine(strchar);
	}
}