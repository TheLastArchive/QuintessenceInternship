using System.Collections.Generic;

namespace DamData
{
    class BinaryTree
    {
        TreeNode root { get; set; } = null;

        public void Add(Dam dam)
        {
            if (root != null)
                root.Add(dam);
            else
                root = new TreeNode(dam);
        }

        public Dam Get(string damToGet)
        {
            OperatorCounter.IncrementOperatorCounter();
            if (damToGet.ToUpper() == root.dam.name)
                return root.dam;
            else
                return root.Get(damToGet.ToUpper());
        }

        public List<Dam> TraverseTree()
        {
            List<Dam> damList = new List<Dam>();
            damList = root?.TraverseTree(damList);
            return damList;
        }
    }
}
