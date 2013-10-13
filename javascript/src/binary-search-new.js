// recursive style
function chopRecursion(target, array) {
    if(array.length == 1 && target == array[0]){
        return 0;
    }
    else
        return -1;
}
