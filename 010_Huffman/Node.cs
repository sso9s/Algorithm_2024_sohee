using System;
using System.Collections.Generic;

namespace _010_Huffman
{
    public class Node
    {
        public char Symbol {  get; set; }
        public int Frequency { get; set; }
        public Node Right { get; set; }
        public Node Left { get; set; }

        internal List<bool> Traverse(char symbol, List<bool> data)
        {
            // Leaf 이면 리턴
            if(Left == null && Right == null)
            {
                if (symbol == this.Symbol)
                    return data;
                else
                    return null;
            }
            else
            {
                List<bool> left = null;
                List<bool> right = null;

                if(Left != null)
                {
                    List<bool> leftPath = new List<bool>();
                    leftPath.AddRange(data);
                    leftPath.Add(false);
                    left = Left.Traverse(symbol, leftPath);
                }
                if(left != null)
                    return left;
                else
                    return right;                         
            }
        }
    }
}