using System;

namespace DataStructures_Trees
{
    public class Node
    {
        private Node _left, _right;
        private int _data;

        public Node(int data)
        {
            _data = data;
        }

        public void insert(int value)
        {
            if (value <= _data)
            {
                if (_left == null)
                    _left = new Node(value);
                else
                    _left.insert(value);
            }
            else
            {
                if (_right == null)
                    _right = new Node(value);
                else
                    _right.insert(value);
            }
        }

        public bool contains(int value)
        {
            if (value == _data)
                return true;
            else if (value < _data)
            {
                if (_left == null)
                    return false;
                else
                    return _left.contains(value);
            }
            else
            {
                if (_right == null)
                    return false;
                else
                    return _right.contains(value);
            }
        }

        public void printInOrder()
        {
            if(_left != null)
                _left.printInOrder();

            Console.WriteLine(_data);
            
            if(_right != null)
                _right.printInOrder();
        }
    }
}