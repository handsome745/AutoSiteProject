using System;
using AutoSiteProject.Models.DB;

namespace AutoSiteProject.Dal.Entities
{
    public class SingletoneAutoSiteProjectDBEntities
    {
        private static AutoSiteProjectDBEntities instance = null;
        private static object syncRoot = new Object();

        private SingletoneAutoSiteProjectDBEntities()
        {
        }

        public static AutoSiteProjectDBEntities Context
        {
            get
            {
                lock (syncRoot)
                {
                    // Thread Safe. Might be costly operation in some case

                    if (instance == null)
                        {
                            instance = new AutoSiteProjectDBEntities();
                        }
                }
                return instance;
            }
        }
    }
}
