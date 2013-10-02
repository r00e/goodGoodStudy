// recursive style
function chopRecursion(target, array) {

	var midPoint = parseInt(array.length/2);

    if(array.length == 0 || array.length == 1 && target != array[midPoint])
    {
        return -1;
    }
	else if(target > array[midPoint])
    {
        return getResult(midPoint, chopRecursion(target, array.slice(midPoint, array.length)));
	}
	else if(target < array[midPoint])
    {
        return getResult(0, chopRecursion(target, array.slice(0, midPoint)));
	}
	else
    {
		return midPoint;
	}
}

function getResult(mid, position){
    return position == -1 ? -1 : mid + position;
}

// iteration style
function chopIteration(target, array){
    var left = 0;
    var mid = parseInt(array.length/2);
    var right = array.length;

    while(left < right){
        if(target < array[mid])
        {
            right = mid;
        }
        else if(target > array[mid])
        {
            left = mid + 1;
        }
        else
        {
            return mid;
        }
        mid = parseInt((left + right)/2);
    }
    return -1;
}

// function call style
function chopFunctionCall(target, array){
    return binarySearch(target, array, 0, array.length);
}

function binarySearch(target, array, left, right){
    var mid = parseInt((left + right)/2);

    if(left < right)
    {
        if(target > array[mid])
        {
            return binarySearch(target, array, mid+1, right);
        }
        else if(target < array[mid])
        {
            return binarySearch(target, array, left, mid);
        }
        else
        {
            return mid;
        }
    }
    else
    {
        return -1;
    }
}
