using System.Text;

namespace AlgorithmLearning.Application.Searches
{
    public static class DepthFirstSearch
    {
        static Node<string> data;

        static DepthFirstSearch()
        {
            // Initialize our sample data
            data = new Node<string>("A",
                new Node<string>("B",
                    new Node<string>("C"), new Node<string>("D")),
                new Node<string>("E",
                    new Node<string>("F"), new Node<string>("G",
                        new Node<string>("H"), null)));
        }

        public static string Locate(string target)
        {
            var result = Find(data, target);

            if (result == null)
                return $"Could not locate '{target}'.";

            StringBuilder builder = new StringBuilder();
            while (result != null)
            {
                builder.AppendLine(result.Value);
                result = result.ParentNode;
            }

            return $"Located '{target}' in the following path: {builder.ToString()}";
        }

        private static Node<T> Find<T>(Node<T> node, T target)
        {
            if (node.Value.Equals(target))
                return node;

            if (node.LeftNode != null)
            {
                Node<T> result = Find(node.LeftNode, target);
                if (result != null)
                    return result;
            }

            if (node.RightNode != null)
            {
                Node<T> result = Find(node.RightNode, target);
                if (result != null)
                    return result;
            }

            return null;
        }

    }
}
