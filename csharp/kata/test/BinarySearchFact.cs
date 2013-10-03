using Xunit;
using Xunit.Extensions;

namespace kata.test
{
    public class ChopRecursionFact
    {
        private readonly BinarySearch chop = new BinarySearch();

        [Fact]
        public void should_be_minus_one_when_array_is_empty()
        {
            Assert.Equal(-1, chop.ChopRecursion(3, new int[] {}));
            Assert.Equal(-1, chop.ChopIteration(3, new int[] { }));
        }

        [Fact]
        public void should_be_minus_one_when_target_is_NOT_in_array()
        {
            Assert.Equal(-1, chop.ChopRecursion(3, new int[] { 1 }));
            Assert.Equal(-1, chop.ChopIteration(3, new int[] { 1 }));            
        }

        [Fact]
        public void should_be_0_for_the_1st_element_if_it_is_found()
        {
            Assert.Equal(0, chop.ChopRecursion(1, new int[] { 1 }));
            Assert.Equal(0, chop.ChopIteration(1, new int[] { 1 }));
        }

        [Theory]
        [InlineData(1, new int[] {1,3,5}, 0)]
        [InlineData(3, new int[] {1,3,5}, 1)]
        [InlineData(5, new int[] {1,3,5}, 2)]
        [InlineData(0, new int[] {1,3,5}, -1)]
        [InlineData(2, new int[] {1,3,5}, -1)]
        [InlineData(4, new int[] {1,3,5}, -1)]
        [InlineData(6, new int[] {1,3,5}, -1)]
        [InlineData(1, new int[] {1,3,5,7}, 0)]
        [InlineData(3, new int[] {1,3,5,7}, 1)]
        [InlineData(5, new int[] {1,3,5,7}, 2)]
        [InlineData(7, new int[] {1,3,5,7}, 3)]
        [InlineData(0, new int[] {1,3,5,7}, -1)]
        [InlineData(2, new int[] {1,3,5,7}, -1)]
        [InlineData(4, new int[] {1,3,5,7}, -1)]
        [InlineData(6, new int[] {1,3,5,7 }, -1)]
        [InlineData(8, new int[] {1,3,5,7 }, -1)]
        public void should_return_right_position_when_target_is_found(int target, int[] array, int returnValue)
        {
            Assert.Equal(returnValue, chop.ChopRecursion(target, array));
            Assert.Equal(returnValue, chop.ChopIteration(target, array));
        }
    }
}