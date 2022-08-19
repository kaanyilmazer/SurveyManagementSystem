using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ErrorModel
{
    public class ErrorViewModel
    {
        public List<string> Errors { get; private set; }
        public bool IsShow { get; private set; }

        public ErrorViewModel()
        {
            Errors = new List<string>();
        }

        public ErrorViewModel(string error, bool isShow)
        {
            Errors.Add(error);
            isShow = true;
        }

        public ErrorViewModel(List<string> errors, bool isShow)
        {
            Errors = errors;
            IsShow = isShow;
        }
    }
}
