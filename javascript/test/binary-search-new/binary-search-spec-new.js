describe("chopRecursion", function() 
	{

	it("should return -1 when array is empty", function(){
		var array = [];
		expect(chopRecursion(3, array)).toEqual(-1);
	});
});
