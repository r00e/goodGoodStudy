describe("chopRecursion", function() 
	{

	it("should return -1 when array is empty", function(){
		var array = [];
		expect(chopRecursion(3, array)).toEqual(-1);
	});

	it("should return -1 when target is NOT in array", function(){
		var array = [1];
		expect(chopRecursion(3, array)).toEqual(-1);
	});

	it("should return 0 when target is the 1st element in array", function(){
		var array = [1];
		expect(chopRecursion(1, array)).toEqual(0);
	});

	it("should return right position when target is in array", function(){
		var array = [1,3,5];
		expect(chopRecursion(1, array)).toEqual(0);
		expect(chopRecursion(3, array)).toEqual(1);
		expect(chopRecursion(5, array)).toEqual(2);
	});
});

describe("chopIteration", function() 
	{

	it("should return -1 when array is empty", function(){
		var array = [];
		expect(chopIteration(3, array)).toEqual(-1);
	});

	it("should return -1 when target is NOT in array", function(){
		var array = [1];
		expect(chopIteration(3, array)).toEqual(-1);
	});

	it("should return 0 when target is the 1st element in array", function(){
		var array = [1];
		expect(chopIteration(1, array)).toEqual(0);
	});

	it("should return right position when target is in array", function(){
		var array = [1,3,5];
		expect(chopIteration(1, array)).toEqual(0);
		expect(chopIteration(3, array)).toEqual(1);
		expect(chopIteration(5, array)).toEqual(2);
	});
});

describe("chopFunctionCall", function() 
	{

	it("should return -1 when array is empty", function(){
		var array = [];
		expect(chopFunctionCall(3, array)).toEqual(-1);
	});

	it("should return -1 when target is NOT in array", function(){
		var array = [1];
		expect(chopFunctionCall(3, array)).toEqual(-1);
	});

	it("should return 0 when target is the 1st element in array", function(){
		var array = [1];
		expect(chopFunctionCall(1, array)).toEqual(0);
	});

	it("should return right position when target is in array", function(){
		var array = [1,3,5];
		expect(chopFunctionCall(1, array)).toEqual(0);
		expect(chopFunctionCall(3, array)).toEqual(1);
		expect(chopFunctionCall(5, array)).toEqual(2);
	});
});

