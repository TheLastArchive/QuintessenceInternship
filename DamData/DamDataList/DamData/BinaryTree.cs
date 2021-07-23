using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamData
{
    class BinaryTree
    {
        TreeNode root { get; set; } = null;

        public void Add(string value)
        {
            if (root != null)
                root.Add(value);
            else
                root = new TreeNode(value);
        }

        public string Get(string value)
        {
            if (value.ToUpper() == root.value)
                return root.value;
            else
                return root.Get(value.ToUpper());
        }
    }
}
