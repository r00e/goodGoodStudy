def getResult(mid, position)
    return position == -1 ? -1 : mid+position
end

def chopRecursion(target, array)
    return -1 if array.empty? || array.size ==1 && target != array[0]
    
    mid = array.size/2
    if target < array[mid]
        return getResult(0, chopRecursion(target, array[0..mid-1]))
    elsif target > array[mid]
        return getResult(mid, chopRecursion(target, array[mid..array.size]))
    else
        return mid
    end
end

def chopIteration(target, array)
    left = 0
    mid = array.size/2
    right = array.size

    while left < right
        if target < array[mid]
            right = mid;
        elsif target > array[mid]
            left = mid + 1
        else
            return mid
        end

        mid = (left + right)/2
    end

    return -1
end
