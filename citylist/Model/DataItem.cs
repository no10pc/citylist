using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using citylist.Helper;
using System.IO;
using System.Windows;
namespace citylist.Model
{
    public class DataItem
    {
        public DataItem(string title)
        {
            Title = title;
        }

        public DataItem()
        {
        }

        public List<BaseInfo> ProvinceItem()
        {
            List<CityTestData> list = new List<CityTestData>();
            XMLManger xml = new XMLManger();
          

            System.Windows.Resources.StreamResourceInfo input = Application.GetResourceStream(new Uri("/citylist;component/SampleData/province.xml", UriKind.Relative));

            list = xml.ParserPovince(input.Stream).ToList();
            
            var data1 = from x in list
                       select x.data;

            List<BaseInfo[]> data2 =data1.ToList();
            List<BaseInfo> info = new List<BaseInfo>();
            foreach (BaseInfo[] data in data2)
            {
                for(int i=0;i<data.Length;i++)
                {
                    info.Add(data[i]);
                }
            }
            return info;
           

        }
        public List<BaseInfo> CityItem(string provincecode)
        {
            List<CityTestData> list = new List<CityTestData>();
            List<BaseInfo> info = new List<BaseInfo>();
            XMLManger xml = new XMLManger();


            System.Windows.Resources.StreamResourceInfo input = Application.GetResourceStream(new Uri("/citylist;component/SampleData/city.xml", UriKind.Relative));

            list = xml.ParseCity(input.Stream).ToList();

            if (provincecode != "")
            {

                var data1 = from x in list
                            where x.CityId==provincecode
                            select x.data;

                List<BaseInfo[]> data2 = data1.ToList();
               
                foreach (BaseInfo[] data in data2)
                {
                    for (int i = 0; i < data.Length; i++)
                    {
                        info.Add(data[i]);
                    }
                }
            }
            return info;
        }

        public List<BaseInfo> CityNextItem(string citycode)
        {
            List<CityTestData> list = new List<CityTestData>();
            List<BaseInfo> info = new List<BaseInfo>();
            XMLManger xml = new XMLManger();

            System.Windows.Resources.StreamResourceInfo input = Application.GetResourceStream(new Uri("/citylist;component/SampleData/city_next.xml", UriKind.Relative));

            list = xml.ParseCity(input.Stream).ToList();

            if (citycode != "")
            {

                var data1 = from x in list
                            where x.CityId == citycode
                            select x.data;

                List<BaseInfo[]> data2 = data1.ToList();

                foreach (BaseInfo[] data in data2)
                {
                    for (int i = 0; i < data.Length; i++)
                    {
                        info.Add(data[i]);
                    }
                }
            }
            return info;
        }

        public string Title
        {
            get;
            private set;
        }

      
    }

}
