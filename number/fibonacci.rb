#1, 1, 2, 3, 5, 8, 13, ...

def fib(n)
	n < 2 ? n : fib(n-1)+fib(n-2)
end

def list_of_fib(max_num)
	max_num = max_num.to_i
	vals = [1, 1]
	i = 3
	while fib(i) <= max_num 
		vals.push fib(i)
		i = i+1
	end

	return vals
end

unless ARGV.length == 1
	p "Usage: ruby fibonacci.rb 100"
    p "The number here 100 is the maximum number in fibonacci."
    exit
end
max_num = ARGV[0]
p list_of_fib(max_num)
