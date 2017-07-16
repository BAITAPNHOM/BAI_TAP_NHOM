﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_DoiTuong
    {
         private string maDT;

        public string MaDT
        {
            get { return maDT; }
            set { maDT = value; }
        }


        private string tenDT;

        public string TenDT
        {
            get { return tenDT; }
            set { tenDT = value; }
        }

        private string chedoMG;

        public string CheDoMG
        {
            get { return chedoMG; }
            set { chedoMG = value; }
        }
        public DTO_DoiTuong(string pmaDT, string ptenDT, string pchedoMG)
        {
            this.maDT = pmaDT;
            this.tenDT = ptenDT;
            this.chedoMG = pchedoMG;
        }
    }
}
