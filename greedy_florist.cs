using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {

    static void Main(String[] args) {
        int N, K;
        string NK = Console.ReadLine();
        string[] NandK = NK.Split(new Char[] {' ', '\t', '\n'});
        N = Convert.ToInt32(NandK[0]);
        K = Convert.ToInt32(NandK[1]);
        
        int [] C = new int [N];
        
        string numbers = Console.ReadLine(); 
        string[] split = numbers.Split(new Char[] {' ', '\t', '\n'});
        
        int i = 0;

        foreach (string s in split){
            if( s.Trim() != ""){
                C[i++] = Convert.ToInt32(s);
            }
        }   
        
        Console.WriteLine(getMinCost(K, C));
    }

    private static int getMinCost(int numFriends, int[] prices) {
        int cost = 0;
        Array.Sort(prices);
        // Console.WriteLine("prices are {0}", string.Join(", ", prices));
        int curr = prices.Length - 1;
        int buyNum = 1;
        while (curr >= 0) {
            int batchSize = Math.Min(curr + 1, numFriends);
            IEnumerable<int> batchFlowers = prices.Skip(curr - batchSize + 1).Take(batchSize);
            // Console.WriteLine("buy next batch of {0} flowers {{ {1} }} at {2}x the cost", batchSize, string.Join(", ", batchFlowers), buyNum);
            cost += batchFlowers.Select(p => p * buyNum).Sum<int>(s => s);
            curr -= batchSize;
            buyNum++;
        }
        return cost;
    }
}
