#include <iostream>

using namespace std;

const int m = 5;
const int n = 4;

const int foo[m] = { 3,3,4,6,7 };
const int bar[n] = { 1,2,5,5 };


void main()
{
	int res[m + n];
	int fooIndex = 0;
	int barIndex = 0;
	for (int i = 0;i < m + n;++i)
	{
		if (foo[fooIndex] < bar[barIndex] || barIndex >= n)
		{
			res[i] = foo[fooIndex++];
		}
		else
		{
			res[i] = bar[barIndex++];
		}
		cout << res[i] << " ";
	}
	getchar();
}