using System;

namespace Tree
{
    public class Tree<T>
    {
        private Node<T> _root;

        public Tree()
        {
            _root = new Node<T>('\0', default, "");
            Count = 1;
        }

        public int Count { get; set; }

        public void Add(string key, T data)
        {
            AddNode(key, data, _root);
        }

        private void AddNode(string key, T data, Node<T> node)
        {
            if (string.IsNullOrEmpty(key))
            {
                if (!node.IsWord)
                {
                    node.Data = data;
                    node.IsWord = true;
                }
            }
            else
            {
                var subnode = node.TryFind(key[0]);
                if (subnode != null)
                {
                    AddNode(key.Substring(1), data, subnode);
                }
                else
                {
                    var newNode = new Node<T>(key[0], data, node.Prefix + key[0]);
                    node.SubNodes.Add(key[0], newNode);
                    AddNode(key.Substring(1), data, newNode);
                }
            }          
        }

        public void Remove(string key)
        {
            RemoveNode(key, _root);
        }

        private void RemoveNode(string key, Node<T> node)
        {
            if (string.IsNullOrEmpty(key))
            {
                if (node.IsWord)
                {
                    node.IsWord = false;
                }
            }
            else
            {
                var subnode = node.TryFind(key[0]);
                if (subnode != null)
                {
                    RemoveNode(key.Substring(1), subnode);
                }
            }
        }

        public bool TrySearch(string key, out T value)
        {
            return SearchNode(key, _root, out value);
        }

        private bool SearchNode(string key, Node<T> node, out T value)
        {
            value = default;
            var result = false;

            if (string.IsNullOrEmpty(key))
            {
                if (node.IsWord)
                {
                    value = node.Data;
                    result = true;
                }
            }
            else
            {
                var subnode = node.TryFind(key[0]);
                if (subnode != null)
                {
                    result = SearchNode(key.Substring(1), subnode, out value);
                }
            }

            return result;
        }
    }
}
