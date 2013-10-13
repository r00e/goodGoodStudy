describe("chopRecursion", function() 
	{

	it("should return -1 when array is empty", function(){
		var array = [];
		expect(chopRecursion(3, array)).toEqual(-1);
	});

    it("should return 0 when array only has 1 element and target is got", function(){
        var array = [3];
		expect(chopRecursion(3, array)).toEqual(0);
    });
});
