function chopRecursion(target, array) {
    return findInHalf(target, array, 0, array.length);
}

function findInHalf(target, array, start, end){
    if(end < start){
        return -1;
    }
    else if(end == start && target == array[start]){
        return end;
    }

    var mid = parseInt( end/2 );
    if( target == array[mid] ){
        return mid;
    }
    else if(target < array[mid]){
        return findInHalf(target, array, start, mid-1);
    }
    else
        return -1;
}
