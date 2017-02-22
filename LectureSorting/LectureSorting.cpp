#include<iostream>
#include <algorithm>

using namespace std;

template<typename Iterator>
void selection_sort(Iterator begin, Iterator end)
{
	while (begin != end)
	{
		Iterator min = min_elem(begin, end);
		iter_swap(begin, min);
		++begin;
	}
}

void bare_selection_sort(int* arr, int size)
{
	for (int i = 0;i < size-1;++i)
	{
		int minIndex = i+1;
		for (int j = i+1;j < size;++j)
		{
			if (arr[minIndex] > arr[j])
			{
				minIndex = j;
			}
		}
		swap(arr[i], arr[minIndex]);
	}
}

void printArr(int* arr, int size)
{
	for (int i = 0;i < size;++i)
	{
		cout << arr[i] << ' ';
	}
	cout << endl;
}

void inserton_sort(int* arr, int size)
{
	for (int i = 0;i < size;++i)
	{
		int value = arr[i];
		int j = i - 1;
		for (;j >= 0 && arr[j] > value;--j)
		{
			arr[j + 1] = arr[j];
		}
		arr[j + 1] = value;
	}
}

int main()
{
	const int size = 4;
	int arr[4] = { 4,3,2,1 };
	printArr(arr, size);
	inserton_sort(arr, size);
	printArr(arr, size);
	getchar();
	return 0;
}