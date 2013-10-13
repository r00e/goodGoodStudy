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
    else
        return -1;
}
