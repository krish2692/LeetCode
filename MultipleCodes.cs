using System;

namespace LEETCODE // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //TopPageSquenceCode();

            TwoSumCode();


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

        public static void TwoSumCode()
        {
                

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