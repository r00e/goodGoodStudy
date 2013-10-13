function chopRecursion(target, array) {
    if(array.length == 0){
        return -1;
    }
    else if(array.length == 1 && target == array[0]){
        return 0;
    }

    var mid = parseInt(array.length/2);
    if( target == array[mid] ){
        return mid;
    }
    else if(target < array[mid]){
        return findInLeftHalf(target, array, mid-1);    
    }
    else
        return -1;
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
