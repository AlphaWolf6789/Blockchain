using Blockchain.First.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Blockchain.First
{
    class Program
    {
        public static List<Block> blockchain = new List<Block>();
        public static int difficulty = 4;

        static void Main(string[] args)
        {

            blockchain.Add(new Block("Ten san pham: Rau bap cai", "0"));
            Console.WriteLine("Trying to Mine block 1... ");
            blockchain.ElementAt(0).MineBlock(difficulty);

            blockchain.Add(new Block("Xuat xu: Hai Duong", blockchain.ElementAt(blockchain.Count - 1).hash));
            Console.WriteLine("Trying to Mine block 2... ");
            blockchain.ElementAt(blockchain.Count - 1).MineBlock(difficulty);

            blockchain.Add(new Block("Ngay thu hoach: 29.12.2022", blockchain.ElementAt(blockchain.Count - 1).hash));
            Console.WriteLine("Trying to Mine block 3... ");
            blockchain.ElementAt(blockchain.Count - 1).MineBlock(difficulty);

            blockchain.Add(new Block("Nha phan phoi: WinMart", blockchain.ElementAt(blockchain.Count - 1).hash));
            Console.WriteLine("Trying to Mine block 4... ");
            blockchain.ElementAt(blockchain.Count - 1).MineBlock(difficulty);

            //blockchain.ElementAt(1).data = "GG";
            //Console.WriteLine("\nBlockchain is Valid: " + IsChainValid());

            Console.WriteLine("\nBlockchain is Valid: " + IsChainValid());
            Console.WriteLine(JsonConvert.SerializeObject(blockchain, Newtonsoft.Json.Formatting.Indented));
            Console.ReadLine();
        }


        public static Boolean IsChainValid()
        {
            Block currentBlock;
            Block previousBlock;

            //Duyet qua tung block de kiem tra ham bam:
            for (int i = 1; i < blockchain.Count; i++)
            {
                currentBlock = blockchain.ElementAt(i);
                previousBlock = blockchain.ElementAt(i - 1);

                //Tinh toan ham bam va so sanh voi ham bam da dang ky
                if (!currentBlock.hash.Equals(currentBlock.CalculateHash()))
                {
                    Console.WriteLine("Current Hashes not equal");
                    return false;
                }

                //So sanh ham bam cua Block hien tai voi Block truoc do
                if (!previousBlock.hash.Equals(currentBlock.previousHash))
                {
                    Console.WriteLine("Previous Hashes not equal");
                    return false;
                }
            }
            return true;
        }

    }
}
