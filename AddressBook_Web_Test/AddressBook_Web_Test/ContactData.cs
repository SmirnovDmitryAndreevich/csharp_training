﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_Web_Test
{
    class ContactData
    {
        private string firstname;
        private string middlename;

        public ContactData(string firstname, string middlename)
        {
            this.firstname = firstname;
            this.middlename = middlename;
        }

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }
        
        public string Middlename
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }
    }
}

