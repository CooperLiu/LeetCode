using LeetCodeSolution;
using Xunit;

namespace LeetCodeSolutionTests
{
    public class Solution2_Tests
    {
        [Fact]
        public void AddTwoNumbers_Test()
        {
            var solution = new Solution2();

            var l1 = new ListNode(3);
            l1.next = new ListNode(4);
            l1.next.next = new ListNode(2);

            var l2 = new ListNode(4);
            l2.next = new ListNode(6);
            l2.next.next = new ListNode(5);


            var res = solution.AddTwoNumbers(l1, l2);


            Assert.Equal(7,res.val);
            Assert.Equal(0,res.next.val);
            Assert.Equal(8,res.next.next.val);

        }
    }
}