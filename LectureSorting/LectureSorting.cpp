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

void merge(int* arr, int from, int middle, int to)
{
	int counter = from;
	int i = from;
	int j = middle + 1;
	int newSize = to - from + 1;
	int* temp = new int[newSize];
	for (int k = 0;k < newSize;++k)
	{
		if (j > to || arr[i] < arr[j] && i <= middle)
		{
			temp[k] = arr[i];
			++i;
		}
		else
		{
			temp[k] = arr[j];
			++j;
		}
	}
	for (int k = 0;k < newSize;++k)
	{
		arr[counter] = temp[k];
		++counter;
	}
	delete temp;
}
void split(int* arr, int from, int to)
{
	if (to - from < 1)
	{
		return;
	}
	int middle = (from + to) / 2;
	if (to - from >= 1)
	{
		split(arr, from, middle);
		split(arr, middle+1, to);
		merge(arr, from, middle, to);
	}
}


int main()
{
	int size = 4;
	int arr[] = { 4,3,2,1 };
	printArr(arr, size);
	split(arr, 0, size-1);
	printArr(arr, size);
	getchar();
	return 0;
}