using System.Collections.Generic;
using Example.Application.DTO;

namespace Example.Web.Models
{
    public class DataItemViewModel : ViewModel
    {
        public IEnumerable<MyDemoDTO> Data { get; set; }

        public MyDemoDTO Item { get; set; }
    }
}