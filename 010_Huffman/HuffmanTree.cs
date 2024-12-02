using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _010_Huffman
{
    public class HuffmanTree
    {
        private List<Node> nodes = new List<Node> (); // 배열이 아니라 리스트로 만듬.
        public Node Root { get; set; }
        public Dictionary<char, int> Frequencies = new Dictionary<char, int> ();

        // 허프만 트리를 만드는 함수
        public void Build(string source)
        {
            // input -> Frequencies Dictionary를 만든다.
            for (int i = 0; i < source.Length; i++)
            {
                if (!Frequencies.ContainsKey(source[i]))
                    Frequencies.Add(source[i], 0);
                Frequencies[source[i]]++;
            }

            // 확인 !
            foreach(var x in Frequencies)
                Console.WriteLine(x.Key + " " + x.Value);

            // nodes를 만든다(교과서의 완전이진트리를 표현하는 배열과 같다)
            // nodes 클래스는 Symbol, Frequency, Right, Left로 구성
            foreach(KeyValuePair<char, int> kvp in Frequencies)
            {
                Node n = new Node() { Symbol = kvp.Key, Frequency = kvp.Value };
                nodes.Add(n);
            }

            while (nodes.Count > 1)
            {
                // 정렬 -> 힙을 만든 것과 같다
                // LINQ, 람다
                List<Node> orderedNodes
                    = nodes.OrderBy(node => node.Frequency).ToList<Node>();

                if (orderedNodes.Count >= 2)
                {
                    // 2개를 가져와서
                    List<Node> taken = orderedNodes.Take(2).ToList<Node>();

                    // 2개를 합쳐서 새로 한개를 만든다.
                    Node parent = new Node()
                    {
                        Symbol = '*',
                        Frequency = taken[0].Frequency + taken[1].Frequency,
                        Left = taken[0],
                        Right = taken[1]
                    };

                    // 2개를 삭제
                    nodes.Remove(taken[0]);
                    nodes.Remove(taken[1]);

                    // 한개 삽입
                    nodes.Add(parent);

                    // Root에 nodes의 첫번째 원소를 지정, 없으면 기본값
                    this.Root = nodes.FirstOrDefault();
                }
            }
        }

        internal BitArray Encode(string input)
        {
            List<bool> encodedSource = new List<bool>();

            for(int i = 0; i < input.Length; i++)
            {
                List<bool> encodedSymbol
                    = this.Root.Traverse(input[i], new List<bool>());
                encodedSource.AddRange(encodedSymbol);
            }
            BitArray bits = new BitArray(encodedSource.ToArray());
            return bits;
        }

        internal string Decode(BitArray bits)
        {
            Node current = this.Root; // Root에서 시작
            string decoded = "";
            foreach (bool bit in bits)
            {
                if (bit)
                {
                    if (current.Right != null)
                        current = current.Right;
                }
                else
                {
                    if (current.Left != null)
                        current = current.Left;
                }
                // 디코딩 하고 current를 Root로 초기화
                if (current.Left == null && current.Right == null) // Leaf node
                {
                    decoded += current.Symbol;
                    current = this.Root;
                }
            }
            return decoded;
        }
    }
}