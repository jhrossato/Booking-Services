using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class GuestDocument
    {
        public string DocumentNumber { get; set; }
        public DocumentType DocumentType { get; set; }
    }
}
