require "test/unit"
require '../src/binary-search-new.rb'

class BinarySearchTest < Test::Unit::TestCase
    def test_chopRecursion
        assert_equal(-1, chopRecursion(3,[]), "should return -1 when array is EMPTY")
        assert_equal(-1, chopRecursion(3,[1]), "should return -1 when target is NOT in array")
        assert_equal(0, chopRecursion(1,[1]), "should return 0 for the 1st element if it is found")
        #
        assert_equal(0,  chopRecursion(1, [1, 3, 5]))
        assert_equal(1,  chopRecursion(3, [1, 3, 5]))
        assert_equal(2,  chopRecursion(5, [1, 3, 5]))
        assert_equal(-1, chopRecursion(0, [1, 3, 5]))
        assert_equal(-1, chopRecursion(2, [1, 3, 5]))
        assert_equal(-1, chopRecursion(4, [1, 3, 5]))
        assert_equal(-1, chopRecursion(6, [1, 3, 5]))
        #
        assert_equal(0,  chopRecursion(1, [1, 3, 5, 7]))
        assert_equal(1,  chopRecursion(3, [1, 3, 5, 7]))
        assert_equal(2,  chopRecursion(5, [1, 3, 5, 7]))
        assert_equal(3,  chopRecursion(7, [1, 3, 5, 7]))
        assert_equal(-1, chopRecursion(0, [1, 3, 5, 7]))
        assert_equal(-1, chopRecursion(2, [1, 3, 5, 7]))
        assert_equal(-1, chopRecursion(4, [1, 3, 5, 7]))
        assert_equal(-1, chopRecursion(6, [1, 3, 5, 7]))
        assert_equal(-1, chopRecursion(8, [1, 3, 5, 7]))
    end

    def test_chopIteration
        assert_equal(-1, chopIteration(3,[]), "should return -1 when array is EMPTY")
        assert_equal(-1, chopIteration(3,[1]), "should return -1 when target is NOT in array")
        assert_equal(0, chopIteration(1,[1]), "should return 0 for the 1st element if it is found")
        #
        assert_equal(0,  chopIteration(1, [1, 3, 5]))
        assert_equal(1,  chopIteration(3, [1, 3, 5]))
        assert_equal(2,  chopIteration(5, [1, 3, 5]))
        assert_equal(-1, chopIteration(0, [1, 3, 5]))
        assert_equal(-1, chopIteration(2, [1, 3, 5]))
        assert_equal(-1, chopIteration(4, [1, 3, 5]))
        assert_equal(-1, chopIteration(6, [1, 3, 5]))
        #
        assert_equal(0,  chopIteration(1, [1, 3, 5, 7]))
        assert_equal(1,  chopIteration(3, [1, 3, 5, 7]))
        assert_equal(2,  chopIteration(5, [1, 3, 5, 7]))
        assert_equal(3,  chopIteration(7, [1, 3, 5, 7]))
        assert_equal(-1, chopIteration(0, [1, 3, 5, 7]))
        assert_equal(-1, chopIteration(2, [1, 3, 5, 7]))
        assert_equal(-1, chopIteration(4, [1, 3, 5, 7]))
        assert_equal(-1, chopIteration(6, [1, 3, 5, 7]))
        assert_equal(-1, chopIteration(8, [1, 3, 5, 7]))
    end
end
