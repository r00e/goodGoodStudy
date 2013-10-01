function chopRecursion(target, array) {

	var midPoint = parseInt(array.length/2);
    var result = 0;

    if(array.length == 0 || array.length == 1 && target != array[midPoint])
    {
        return -1;
    }
	else if(target > array[midPoint])
    {
        result = chopRecursion(target, array.slice(midPoint, array.length));
        return getResult(midPoint, result);
	}
	else if(target < array[midPoint])
    {
        result = chopRecursion(target, array.slice(0, midPoint));
        return getResult(0, result);
	}
	else
    {
		return midPoint;
	}
}

function getResult(mid, position){
    if(position == -1){
        return -1;
    }
    else{
        return mid + position;
    }
}



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
