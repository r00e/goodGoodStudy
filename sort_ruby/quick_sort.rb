$times = 0

def partition(array, low, high)
	target = array[low]
	while (low < high) do
		while (low < high && target < array[high]) do
			high = high - 1
		end
		array[low] = array[high]
		while (low < high && target >= array[low]) do
			low = low + 1
		end
		array[high] = array[low]
	end
	array[low] = target
	$times = $times + 1
	return low
end

def quick_sort(array, low, high)
	if (low < high)
		pos = partition(array, low, high)
		quick_sort(array, low, pos-1)
		quick_sort(array, pos+1, high)
	end
end

array = [3,2,7,1,4,6,5]
p "Given #{array}"
quick_sort(array, 0, 6)
p "After #{$times} times, sort result is #{array}"