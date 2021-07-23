using System.Collections.Generic;

namespace DamData
{
    class TreeNode
    {
        public Dam dam { get; set; }
        public TreeNode leftNode { get; set; } = null;
        public TreeNode rightNode { get; set; } = null;

        public TreeNode(Dam dam) => this.dam = dam;

        public void Add(Dam dam)
        {
            OperatorCounter.IncrementOperatorCounter();
            if (dam.name.Length >= this.dam.name.Length)
            {
                if (rightNode is null)
                    rightNode = new TreeNode(dam);
                else
                    rightNode.Add(dam);
            }
            else
            {
                if (leftNode is null)
                    leftNode = new TreeNode(dam);
                else
                    leftNode.Add(dam);
            }
        }

        public Dam Get(string value)
        {
            OperatorCounter.IncrementOperatorCounter();
            if (dam.name == value)
                return dam;

            OperatorCounter.IncrementOperatorCounter();
            if (dam.name.Length <= value.Length)
                return rightNode?.Get(value);

            OperatorCounter.IncrementOperatorCounter();
            if (dam.name.Length > value.Length)
                return leftNode?.Get(value);

            return null;
        }

        public List<Dam> TraverseTree(List<Dam> damList)
        {
            damList.Add(dam);
            leftNode?.TraverseTree(damList);
            rightNode?.TraverseTree(damList);
            return damList;
        }
    }
}
