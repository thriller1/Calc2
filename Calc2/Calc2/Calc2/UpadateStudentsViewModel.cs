using MobileBillSoft.UiLayer.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using WebApplication1;
using ZbService.DomainModel;

namespace Calc2
{
    class UpadateStudentsViewModel: BaseViewModel
    {
        public ObservableCollection<Student> StudentList { get; set; }



        public UpadateStudentsViewModel()
        {
            StudentList = new ObservableCollection<Student>();
        }

        internal void Validate()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, "http://10.15.0.50/WebApplication1/api/Students9/Students");
            HttpResponseMessage requst = client.SendAsync(msg).Result;

            String val = requst.Content.ReadAsStringAsync().Result;
            MbsResult mb = JsonConvert.DeserializeObject<MbsResult>(val);

            if (mb == null)
            {
                // return(mb.FirstMessage));
            }
            else
            {
                var r = mb.Result;
                List<Student> ListStudents = JsonConvert.DeserializeObject<List<Student>>(r.ToString());

                StudentList.Clear();
                foreach (Student s in ListStudents)
                {
                    if (s == null || string.IsNullOrEmpty(s.Name))
                    {
                        continue;
                    }
                    StudentList.Add(s);
                }
            }
        }
    }
}
