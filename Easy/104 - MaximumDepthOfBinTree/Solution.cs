/// Question 104. Maximum Depth of Binary Tree
/// Difficulty: Easy
/// 执行用时: 116 ms, 在所有 C# 提交中击败了 52.15% 的用户
/// 内存消耗: 25.5 MB, 在所有 C# 提交中击败了 8.00% 的用户

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution
{
    public int MaxDepth(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        if (root.left == null && root.right == null)
        {
            // Leaf
            return 1;
        }

        if (root.left != null && root.right == null)
        {
            return 1 + MaxDepth(root.left);
        }

        if (root.left == null && root.right != null)
        {
            return 1 + MaxDepth(root.right);
        }

        int leftBranchDepth = MaxDepth(root.left);
        int rightBranchDepth = MaxDepth(root.right);

        return 1 + (leftBranchDepth > rightBranchDepth ? leftBranchDepth : rightBranchDepth);
    }
}


public class SolutionTopDown
{
    /// 执行用时: 112 ms, 在所有 C# 提交中击败了 72.83% 的用户
    /// 内存消耗: 25.5 MB, 在所有 C# 提交中击败了 12.50% 的用户
    private int answer = 0;

    public int MaxDepth(TreeNode root)
    {
        this.FindMaxDepth(root, 1);
        return answer;
    }

    private void FindMaxDepth(TreeNode root, int depth)
    {
        if (root == null)
        {
            return;
        }

        if (root.left == null && root.right == null)
        {
            this.answer = Math.Max(answer, depth);
        }

        FindMaxDepth(root.left, depth + 1);
        FindMaxDepth(root.right, depth + 1);
    }
}