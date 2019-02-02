using MobileBillSoft.UiLayer.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WebApplication1;
using ZbService.DomainModel;

namespace Calc2
{
    class InsertStudentViewModel:BaseViewModel
    {

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                SetProperty(ref name, value);
            }
        }
        private int rollno;
        public int RollNo
        {
            get
            {
                return rollno;
            }
            set
            {
                SetProperty(ref rollno, value);
            }
        }


        public InsertStudentViewModel()
        {

        }

        internal string  AddStudents()
        {
          

            if(Name==null || rollno==0)
            {
                
                return ("Please fill All the Felids");
            }

            Student newstudent = new Student();
            newstudent.Name = Name;
            newstudent.RollNo = RollNo;
            var parseMsg = JsonConvert.SerializeObject(newstudent);

            StringContent stringContent = new StringContent(parseMsg, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Post, "http://localhost/WebApplication1/api/Students9/Students");
            msg.Content = stringContent;
            HttpResponseMessage req = client.SendAsync(msg).Result;
           
            var rtnvalue = req.Content.ReadAsStringAsync().Result;
            MbsResult mb = JsonConvert.DeserializeObject<MbsResult>(rtnvalue);
            if(mb.Status==false)
            {
                return (mb.FirstMessage);

            }
            else
            {
                var finalResult = mb.Result;
                Student newStudent = JsonConvert.DeserializeObject<Student>(finalResult.ToString());
             //   return "New Student Added successfully";
            }

            return "New Student Added successfully";

        }
    }
}
