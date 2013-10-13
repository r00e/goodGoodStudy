function chopRecursion(target, array) {
    return findInLeftHalf(target, array, array.length);
}

function findInLeftHalf(target, array, end){
    if(end < 0){
        return -1;
    }
    else if(end == 0 && target == array[0]){
        return end;
    }

    var mid = parseInt( end/2 );
    if( target == array[mid] ){
        return mid;
    }
    else if(target < array[mid]){
        return findInLeftHalf(target, array, mid-1);
    }
    else
        return -1;
}
