using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using _153501_MIROOLYUBOV_lab5.Interfaces;


namespace _153501_MIROOLYUBOV_lab5.Collections
{

    public class MyCustomCollection<T> : ICustomCollection<T>
    {

        public int Count { get; private set; } = 0;
        public class Node
        {
            public Node(T data)
            {
                Data = data;
                Next = null;
            }
            public T Data { get; set; }
            public Node? Next { get; set; }
        }

        private Node? head = null;

        public Node? currentNode = null;
        public T this[int index]
        {
            get
            {
                if (index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }

                Node? currentNode = head;

                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }

                return currentNode.Data;
            }
            set
            {

                if (index >= Count)
                    throw new IndexOutOfRangeException();
                Node buff = new Node(value);

                Node? currentNode = head;
                Node? previousNode = null;

                for (int i = 0; i < index; i++)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.Next;
                }

                buff.Next = currentNode.Next;
                if (previousNode != null)
                {
                    previousNode.Next = buff;
                }
                else
                {
                    head = buff;
                }
            }
        }
        public void Reset() => currentNode = head;

        public void Next() => currentNode = currentNode?.Next;

        public T Current()
        {
            if (currentNode == null)
                throw new IndexOutOfRangeException();
            return currentNode.Data;
        }
        public void Add(T value)
        {
            if (head == null)
            {
                head = new Node(value);
                currentNode = head;
            }
            else
            {
                Reset();
                //Node currentNode = head;
                for (int i = 0; i < Count - 1; i++)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = new Node(value);
                currentNode = currentNode.Next;
            }
            Count++;
        }
        public void Remove(T item)
        {
            Node currentNode = head;
            Node previousNode = null;

            int i = 0;
            int chek = 0;
            while(!currentNode.Data.Equals(item))
            {
                i++;
                if (i >= Count)
                {
                    chek = 1;
                    break;
                }
                previousNode = currentNode;
                currentNode = currentNode.Next;
                
            }

            if (chek == 1) 
            {
                throw new Exception("This object don't exist in your list");
            }
            else
            {
                if (previousNode == null)
                {
                   head = currentNode.Next;
                }
                else
                {
                    previousNode.Next = currentNode.Next;
                }
                Count--;
            }
            
        }
        public T RemoveCurrent()
        {
            Node previousNode = head;
            for (int i = 0; i < Count; i++)
            {
                if (previousNode.Next.Equals(currentNode))
                {
                    break;
                }
            }
            previousNode.Next = currentNode.Next;
            previousNode = currentNode;
            currentNode = currentNode.Next;
            Count--;
            return previousNode.Data;
        }
    }
}