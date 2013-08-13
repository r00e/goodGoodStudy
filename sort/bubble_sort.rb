def bubble_sort(array)
	for i in 0..array.size-1
		for j in i..array.size-1
			if array[i] > array[j]
				temp = array[i]
				array[i] = array[j]
				array[j] = temp
			end
		end
	end
end

array = [3,2,7,1,4,6,5]
p "Given #{array}"
bubble_sort(array)
p "Then #{array}"