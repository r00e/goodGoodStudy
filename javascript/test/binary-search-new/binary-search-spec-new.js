describe("chopRecursion", function(){

	it("should return -1 when array is empty", function(){
		var array = [];
		expect(chopRecursion(3, array)).toEqual(-1);
	});

    it("should return 0 when array only has 1 element and target is got", function(){
        var array = [3];
		expect(chopRecursion(3, array)).toEqual(0);
    });

    it("should return correct position when the target is at the middle of array", function(){
        var array = [1,3];
		expect(chopRecursion(3, array)).toEqual(1);

        array = [2,4,6];
		expect(chopRecursion(4, array)).toEqual(1);
    });

    it("should return correct position when target is at the left side of mid",function(){
        var array = [1,3];
		expect(chopRecursion(1, array)).toEqual(0);

        array = [2,4,6];
		expect(chopRecursion(2, array)).toEqual(0);

        array = [2,4,6,8,10,12];
		expect(chopRecursion(4, array)).toEqual(1);

        array = [1,3,5,7,9,11,13,15,17,19,21,23,25];
		expect(chopRecursion(5, array)).toEqual(2);
    });

    it("should return correct position when target is at the right side of mid", function(){
        var array = [1,3,5];
		expect(chopRecursion(5, array)).toEqual(2);

        array = [2,4,6,8,10,12];
		expect(chopRecursion(12, array)).toEqual(5);
    });
});
