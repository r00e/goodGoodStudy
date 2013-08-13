def merge(array, first, mid, last)
	i = first
	j = mid
	k = 0
	temp = Array.new(last-first+1) { 0 }
	p temp

	while i <= mid && j <= last
		if array[i] < array[j]
			temp[k] = array[i]
			i += 1
		else
			temp[k] = array[j]
			j += 1
		end
		k += 1
	end
	while i <= mid
		temp[k] = array[i]
		k += 1
		i += 1
	end
	while j <= last
		temp[k] = array[j]
		k += 1
		i += 1
	end
	for m in 0..k-1
		array[first+m] = temp[m]
	end
	p array
	return array
end

def merge_sort(array, first, last)
	if first < last
		mid = (first+last)/2
		merge_sort(array, first, mid)
		merge_sort(array, mid+1, last)
		merge(array, first, mid+1, last)
	end
end

array = [3,2,7,1,4,6,5]
p "Given #{array}"
merge_sort(array, 0, 6)
p "Then #{array}"