using System;

namespace LEETCODE // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //TopPageSquenceCode();

            // Console.WriteLine("Indexing Summing to 4 in { 1, 1, 2, 1, 1, 2 } are:  {");
            // foreach (int i in TwoSumCode(new int[] { 1, 1, 2, 1, 1, 2 }, 4))
            //     Console.Write(i + " ");

            MissingNumber(new int[] { 5, 4, 2, 1, 9, 6, 3, 7 });


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
            int n=nums.Length+1;
            Console.WriteLine("Array for finding the Missing Number: ");
            for (int i = 1; i <= n; i++)
            {
                actual_sum += i;
                //Console.WriteLine(" " + nums[i-1]);
            }
            //Alternatively:
            int alternate_actual_sum=(n*(n+1))/2 - sum;
            Console.WriteLine("The Missing number is " + (actual_sum - sum) + " ------------  Alternative Solution: " + alternate_actual_sum);
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