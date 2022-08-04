using System;

namespace LEETCODE // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*TopPageSquenceCode();

            Console.WriteLine("Indexing Summing to 4 in { 1, 1, 2, 1, 1, 2 } are:  {");
            foreach (int i in TwoSumCode(new int[] { 1, 1, 2, 1, 1, 2 }, 4))
                Console.Write(i + " ");

            MissingNumber(new int[] { 5, 4, 2, 1, 9, 6, 3, 7 });

            //Amazon telephonic interview Question
            Console.WriteLine("Shuffled Playlist for Playlist:  {1,2,3,4,5,6,7,8,9} using :");
            ShufflePlayList(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 3);*/

            DictionaryCountEinGivenRange();



        }


        public static void TopPageSquenceCode()
        {
            byte[] Tran = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            string[] UserName = new string[] { "joe", "joe", "joe", "james", "james", "james", "james", "mary", "mary", "mary" };
            string[] Sites = new string[] { "home", "about", "career", "home", "carts", "maps", "home", "home", "about", "career" };

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            UserLog? objUserLog;
            List<UserLog> lstUserLog = new List<UserLog>();

            for (int i = 0; i < UserName.Length; i++)
            {
                objUserLog = lstUserLog.Find(h => h.username.Equals(UserName[i]));

                if (objUserLog != null)
                {
                    objUserLog.sites.Add(Sites[i]);
                }
                else
                {
                    objUserLog = new UserLog(UserName[i], Sites[i]);
                    lstUserLog.Add(objUserLog);
                }
            }

            Dictionary<string, int> SiteVisits = new Dictionary<string, int>();

            foreach (UserLog obj in lstUserLog)
            {
                int cnt = obj.sites.Count;

                for (int i = 0; i < cnt - 2; i++)
                {
                    for (int j = i + 1; j < cnt - 1; j++)
                    {
                        for (int k = j + 1; k < cnt; k++)
                        {
                            string siteseq = "{" + obj.sites[i] + "-" + obj.sites[j] + "-" + obj.sites[k] + "}";
                            //Console.Write(siteseq);

                            if (!SiteVisits.TryAdd(siteseq, 1))
                                SiteVisits[siteseq] = SiteVisits[siteseq] + 1;
                        }
                    }
                }

            }

            Console.WriteLine("Maximum Visited Sites Sequence:" + SiteVisits.Aggregate((x, y) => x.Value > y.Value ? x : y).Key);
            watch.Stop();

            Console.WriteLine("TimeTaken to execute the code: " + watch.ElapsedMilliseconds);

            foreach (KeyValuePair<string, int> pair in SiteVisits)
            {
                Console.WriteLine(pair.Key + "------> " + pair.Value);
            }
        }

        public static int[] TwoSumCode(int[] nums, int target)
        {
            int arrayLength = nums.Length;

            Dictionary<int, int> result = new();

            if (nums == null || arrayLength < 2)
                return Array.Empty<int>();


            for (int i = 0; i < arrayLength; i++)
            {
                int first_number = nums[i];
                int second_number = target - first_number;

                if (result.TryGetValue(second_number, out int index))
                {
                    return new[] { index, i };
                }

                result[first_number] = i;
            }
            return new int[] { 0 };
        }

        public static void MissingNumber(int[] nums)
        {
            int actual_sum = 0;
            int sum = nums.Sum();
            int n = nums.Length + 1;
            Console.WriteLine("Array for finding the Missing Number: ");
            for (int i = 1; i <= n; i++)
            {
                actual_sum += i;
                //Console.WriteLine(" " + nums[i-1]);
            }
            //Alternatively:
            int alternate_actual_sum = (n * (n + 1)) / 2 - sum;
            Console.WriteLine("The Missing number is " + (actual_sum - sum) + " ------------  Alternative Solution: " + alternate_actual_sum);
        }

        public static void ShufflePlayList(int[] songs, int playbackLimit)
        {
            int n = songs.Length;

            HashSet<int> Shuffled = new HashSet<int>();

            Dictionary<int, int> DictShuffled = new Dictionary<int, int>();


            Random rand = new Random();

            while (Shuffled.Count != n)
            {
                int Random_index = rand.Next(0, n);

                if (!Shuffled.TryGetValue(songs[Random_index], out int index))
                    Shuffled.Add(songs[Random_index]);

            }

            for (int i = 0; DictShuffled.Values.Distinct().ToList().Count != n; i++)
            {
                int Random_index = rand.Next(0, n);

                if (i == 0)
                    DictShuffled.Add(i, songs[Random_index]);
                else
                {
                    bool isDuplicate = false;
                    for (int k = DictShuffled.Count - 1, j = 0; j < playbackLimit && k >= 0; j++, k--)
                    {
                        if (DictShuffled.ElementAt(k).Value == songs[Random_index])
                        {
                            isDuplicate = true;
                            break;
                        }
                    }
                    if (!isDuplicate)
                        DictShuffled.Add(i, songs[Random_index]);
                }
            }

            Console.Write("\nHashset (no duplicate songs) : { ");
            foreach (int s in Shuffled)
            {
                Console.Write(s + " ");
            }
            Console.Write(" }");

            Console.Write("\nDictionary (with duplicate songs) playbackLimit:" + playbackLimit + " : { ");

            foreach (KeyValuePair<int, int> a in DictShuffled)
            {
                Console.Write(a.Value + " ");
            }
            Console.Write(" }");

        }

        public static void DictionaryCountEinGivenRange()
        {
            int lower = 1, upper = 10;//default
            string Number = string.Empty;
            try
            {
                Console.WriteLine("Enter Lower Limit: ");
                lower = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Upper Limit: ");
                upper = Convert.ToInt32(Console.ReadLine());

                Dictionary<string, int> OutputDictionary = new Dictionary<string, int>();

                for (int i = lower; i <= upper; i++)
                {
                    Number = GetSpelledNumber(i);
                    if (Number.Contains('e'))
                    {
                        int cnt = 0;
                        for (int j = 0; j < Number.Length; j++)
                        {
                            if (Number[j].Equals('e') || Number[j].Equals('E'))//'E' in case of  Eight
                                cnt++;
                        }
                        OutputDictionary.Add(Number, cnt);
                    }
                    else
                        OutputDictionary.Add(Number, 0);
                }

                Console.WriteLine(Environment.NewLine + "Output (Count of E or e in each number in the range):");

                foreach (var pair in OutputDictionary)
                    Console.WriteLine("({0}, {1})", pair.Key, pair.Value);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

         private static string GetSpelledNumber(int x)
        {
            Dictionary<int, string> PrivateDictionary = new Dictionary<int, string>();
            try
            {
                PrivateDictionary.Add(1, "One");
                PrivateDictionary.Add(2, "Two");
                PrivateDictionary.Add(3, "Three");
                PrivateDictionary.Add(4, "Four");
                PrivateDictionary.Add(5, "Five");
                PrivateDictionary.Add(6, "Six");
                PrivateDictionary.Add(7, "Seven");
                PrivateDictionary.Add(8, "Eight");
                PrivateDictionary.Add(9, "Nine");
                PrivateDictionary.Add(10, "Ten");
                PrivateDictionary.Add(11, "Eleven");
                PrivateDictionary.Add(12, "Twelve");
                PrivateDictionary.Add(13, "Thirteen");
                PrivateDictionary.Add(14, "Fourteen");
                PrivateDictionary.Add(15, "Fifteen");
                PrivateDictionary.Add(16, "Sixteen");
                PrivateDictionary.Add(17, "Seventeen");
                PrivateDictionary.Add(18, "Eighteen");
                PrivateDictionary.Add(19, "Nineteen");
                PrivateDictionary.Add(20, "Twenty");
                PrivateDictionary.Add(30, "Thirty");
                PrivateDictionary.Add(40, "Forty");
                PrivateDictionary.Add(50, "Fifty");
                PrivateDictionary.Add(60, "Sixty");
                PrivateDictionary.Add(70, "Seventy");
                PrivateDictionary.Add(80, "Eighty");
                PrivateDictionary.Add(90, "Ninety");
                PrivateDictionary.Add(0, string.Empty);

                if (x >= 100)
                    return GetSpelledNumber(x / 100) + " Hundred " + GetSpelledNumber(x % 100);//Example 423 = 42/100 = Four Hundred, (23/10 = 2*10 = 20) Twenty, 23%10 = 3, Four Hundred Twenty Three  
                if (x >= 21)
                    return PrivateDictionary[x / 10 * 10] + " " + PrivateDictionary[x % 10];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return PrivateDictionary[x].ToString();
        }
    }
    public class UserLog
    {
        public string username;
        public List<string> sites;

        public UserLog(string username, string site)
        {
            this.sites = new List<string>();
            this.username = username;
            this.sites.Add(site);

        }
    }
}