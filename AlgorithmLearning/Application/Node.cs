using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLearning.Application
{
    public class Node<T>
    {
        public Node<T> ParentNode { get; set; }
        public Node<T> LeftNode { get; set; }
        public Node<T> RightNode { get; set; }
        public T Value { get; set; }

        public Node(T value, Node<T> leftNode, Node<T> rightNode)
        {
            Value = value;
            if (leftNode != null) leftNode.ParentNode = this;
            if (rightNode != null) rightNode.ParentNode = this;
            LeftNode = leftNode;
            RightNode = rightNode;
        }

        public Node(T value)
        {
            Value = value;
            LeftNode = RightNode = null;
        }
    }
}
