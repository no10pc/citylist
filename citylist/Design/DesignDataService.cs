using System;
using citylist.Model;

namespace citylist.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("Welcome to MVVM Light [design]");
            var province = new DataItem().ProvinceItem();
            callback(item, null);
        }
    }
}