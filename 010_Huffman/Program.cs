using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _010_Huffman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "Yesterday all my troubles seemed so far away. Now it looks as though they're here to stay. Oh, I believe in yesterday. Suddenly I'm not half the man I used to be. There's a shadow hanging over me. Oh, yesterday came suddenly. Why she had to go, I don't know, she wouldn't say. I said something wrong, now I long for yesterday. Yesterday love was such an easy game to play. Now I need a place to hide away. Oh, I believe in yesterday. Why she had to go, I don't know, she wouldn't say. I said something wrong, now I long for yesterday. Yesterday love was such an easy game to play. Now I need a place to hide away. Oh, I believe in yesterday.  Mm mm mm mm mm mm mm";

            HuffmanTree hTree = new HuffmanTree();

            // Build Huffman Tree
            hTree.Build(input);

            // Encode
            BitArray encoded = hTree.Encode(input);

            Console.Write("Encoded : ");
            foreach (bool bit in encoded)
            {
                Console.Write(bit ? 1 : 0); // 조건연산자
            }
            Console.WriteLine();

            // Decode
            string decoded = hTree.Decode(encoded);

            Console.Write("Decoded : " + decoded);
            Console.WriteLine();

            Console.WriteLine("Encoded : {0} bits", encoded.Length);
            Console.WriteLine("Decoded : {0} bits", decoded.Length * 8);
            Console.WriteLine("압축율 : {0:F1} %", (double)encoded.Length / (decoded.Length * 8) * 100);
        }
    }
}

// 빈도수를 체크해서 힙을 채우고 힙을 만들고?
// 두개가 합쳐져서 하나가 되는 과정 
// 힙을 이용해서 만들어진 트리 -> 허프만 트리
// 힙하고 히프만 트리하고 혼동하면 안됨.