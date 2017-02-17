#include <iostream>
#include <algorithm>

using namespace std;

const int m = 3;
const int n = 3;
const int toFind = 0;
const int matrix[n][m] = 
{
	{1,2,3},
	{4,5,6},
	{7,8,9}
};
					
int main()
{
	int m = ::m-1;
	int n = ::n-1;
	for (int i = 0;i < ::m;++i)
	{
		for (int j = 0;j < ::n;++j)
		{
			cout << matrix[i][j] << ' ';
		}
		cout << endl;
	}
	try
	{
		for (int k = 0;k < ::m + ::n;++k)
		{
			if (matrix[n][m - 1] >= toFind)
			{
				--m;
			}
			if (matrix[n - 1][m] >= toFind)
			{
				--n;
			}
			if (n < 0 || m < 0)
			{
				throw std::logic_error("Error 404: Element not found");
			}
			if (matrix[n][m] == toFind)
			{
				break;
			}
		}
		cout << "Founded at [" << n << ';' << m << ']';
	}
	catch(logic_error error)
	{
		cout << error.what();
	}
	getchar();
	return 0;
}