#include <iostream>

using namespace std;

bool isSimple(int n)
{
	if (n <= 1)
	{
		return false;
	}
	int range = static_cast<int>(sqrt(n));
	for (int i = 2;i <= range;++i)
	{
		if (n%i == 0)
		{
			return false;
		}
	}
	return true;
}

bool testCorrectSimple()
{
	const int simple[] = { 71, 73, 79, 599, 601, 607, 613, 617, 619, 631, 641, 643, 647 };
	const int count = 13;
	for (int i = 0;i < count;++i)
	{
		if (!isSimple(simple[i]))
		{
			return false;
		}
	}
	return true;
}

bool testCorrectBasic()
{
	const int simple[] = { 71, 73, 79, 599, 601, 607, 613, 617, 619, 631, 641, 643, 647 };
	const int count = 13;
	for (int i = 0;i < count;++i)
	{
		if (isSimple(simple[i]+1))
		{
			return false;
		}
	}
	return true;
}

void main()
{
	cout << boolalpha << testCorrectSimple() << " " << testCorrectBasic();
	getchar();
}