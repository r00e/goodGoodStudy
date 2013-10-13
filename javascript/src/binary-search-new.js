function chopRecursion(target, array) {
    return findInHalf(target, array, 0, array.length);
}

function findInHalf(target, array, start, end){
    var mid = parseInt( (start + end) / 2 );
    if(start < end){
        if(target < array[mid]){
            return findInHalf(target, array, start, mid);
        }
        else if(target > array[mid]){
            return findInHalf(target, array, mid+1, end);
        }
        else{
            return mid;
        }
    }
    else
        return -1;
}
