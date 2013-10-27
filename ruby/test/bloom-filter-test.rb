require "test/unit"
require '../src/bloom-filter.rb'

class BloomFilterTest < Test::Unit::TestCase
    def test_initBitmap
        assert_equal([0,0,0], initBitmap(3), "should return [0,0,0] when initialize Bitmap when size is 3")
    	assert_not_equal([0,0,0,0], initBitmap(3), "should be an array which size is 3")
        assert_not_equal([1,0,0], initBitmap(3), "all default value in Bitmap should be 0")
        assert_not_equal([0,1,0], initBitmap(3), "all default value in Bitmap should be 0")
        assert_not_equal([0,0,1], initBitmap(3), "all default value in Bitmap should be 0")
    end

    def test_search
        map = initBloomFilter(100)
        
        assert_equal(true, search("a", map))
        assert_equal(true, search("Aaron", map))
        assert_equal(false, search("xxx", map))
    end
end
