using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamData
{
    class TreeNode
    {
        public string value { get; set; }
        public TreeNode leftNode { get; set; } = null;
        public TreeNode rightNode { get; set; } = null;

        public TreeNode(string value) => this.value = value;

        public void Add(string value)
        {
            if (value.Length >= this.value.Length)
            {
                if (rightNode is null)
                    rightNode = new TreeNode(value);
                else
                    rightNode.Add(value);
            }
            else
            {
                if (leftNode is null)
                    leftNode = new TreeNode(value);
                else
                    leftNode.Add(value);
            }
        }

        public string Get(string value)
        {
            if (this.value == value)
                return value;

            else if (this.value.Length <= value.Length)
                return rightNode?.Get(value);

            else if (this.value.Length > value.Length)
                return leftNode?.Get(value);

            return null;
        }
    }
}
